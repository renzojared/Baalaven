using Baalaven.Entities.Exceptions;
using Baalaven.Entities.Interfaces;
using Baalaven.Entities.POCOEntities;
using Baalaven.Entities.Specifications;
using Baalaven.UseCases.Common.Validators;
using Baalaven.UseCasesDTOs.GetAllOrders;
using Baalaven.UseCasesPorts.GetAllOrders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baalaven.UseCases.GetAllOrders
{
    public class GetAllOrdersInteractor : IGetAllOrdersInputPort
    {
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IProductRepository productRepository;
        readonly IGetAllOrdersOutputPort outputPort;
        readonly IEnumerable<IValidator<GetAllOrdersParams>> validators;

        public GetAllOrdersInteractor(IOrderDetailRepository orderDetailRepository, 
            IProductRepository productRepository, 
            IGetAllOrdersOutputPort outputPort, 
            IEnumerable<IValidator<GetAllOrdersParams>> validators)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.productRepository = productRepository;
            this.outputPort = outputPort;
            this.validators = validators;
        }

        public async Task Handle(GetAllOrdersParams getAllOrders)
        {
            await Validator<GetAllOrdersParams>.Validate(getAllOrders, validators);

            var output = new GetAllOrdersOutputPort();
            output.Orders = new List<GetAllOrder>();

            try
            {
                var expressionOrderDetail = new Specification<OrderDetail>(s => s.Order.CustomerId.ToLower() == getAllOrders.CustomerId.ToLower());
                var ordersDetail = orderDetailRepository.GetOrdersDetailByEspecification(expressionOrderDetail).ToList();

                var productsId = ordersDetail.Select(s => s.ProductId).Distinct().ToList();
                var expressionProduct = new Specification<Product>(s => productsId.Contains(s.Id));
                var products = productRepository.GetProductsByEspecification(expressionProduct).ToList();

                var ordersId = ordersDetail.Select(s => s.Order.Id).Distinct().ToList();
                foreach (var id in ordersId)
                {
                    var order = ordersDetail
                        .Where(s => s.Order.Id == id)
                        .Select(s => new GetAllOrder(
                            s.Order.OrderDate,
                            s.Order.ShipAddress,
                            s.Order.ShipCity,
                            s.Order.ShipCountry,
                            s.Order.ShipPostalCode,
                            s.Order.DiscountType,
                            s.Order.Discount,
                            s.Order.ShippingType
                            ))
                        .FirstOrDefault();
                    var detail = ordersDetail
                        .Where(f => f.Order.Id == id)
                        .Select(s => new GetAllOrderDetail(
                            products.FirstOrDefault(d => d.Id == s.ProductId).Name,
                            s.UnitPrice,
                            s.Quantity
                            ))
                        .ToList();
                    order.SetOrderDetails(detail);
                    output.Orders.Add(order);
                }
            }
            catch (Exception ex)
            {

                throw new GeneralException("Error getting order", ex.Message);
            }
            await outputPort.Handle(output);
        }
    }
}
