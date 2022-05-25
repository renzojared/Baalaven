using Baalaven.Entities.Exceptions;
using Baalaven.Entities.Interfaces;
using Baalaven.Entities.POCOEntities;
using Baalaven.UseCases.Common.Validators;
using Baalaven.UseCasesDTOs.CreateOrder;
using Baalaven.UseCasesPorts.CreateOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Baalaven.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateOrderOutputPort OutputPort;
        readonly IEnumerable<IValidator<CreateOrderParams>> Validators;

        public CreateOrderInteractor(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOfWork unitOfWork,
            ICreateOrderOutputPort outputPort,
            IEnumerable<IValidator<CreateOrderParams>> validators) =>
            (OrderRepository, OrderDetailRepository, UnitOfWork, OutputPort, Validators) =
            (orderRepository, orderDetailRepository, unitOfWork, outputPort, validators);

        public async Task Handle(CreateOrderParams order)
        {
            await Validator<CreateOrderParams>.Validate(order, Validators);
            Order Order = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddres = order.ShippAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipPostalCode = order.ShipPostalCode,
                ShippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };
            OrderRepository.Create(Order);
            foreach (var Item in order.OrderDetails)
            {
                OrderDetailRepository.Create(
                    new OrderDetail
                    {
                        Order = Order,
                        ProductId = Item.ProductId,
                        UnitPrice = Item.UnitPrice,
                        Quantity = Item.Quantity
                    });
            }
            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden.", ex.Message);
            }
            await OutputPort.Handle(Order.Id);
        }
    }
}