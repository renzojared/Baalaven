using Baalaven.Entities.Exceptions;
using Baalaven.Entities.Interfaces;
using Baalaven.Entities.POCOEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Baalaven.UsesCases.CreateOrder
{
    public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int>
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;

        public CreateOrderInteractor(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOfWork unitOfWork) =>
            (OrderRepository, OrderDetailRepository, UnitOfWork) =
            (orderRepository, orderDetailRepository, unitOfWork);
        public async Task<int> Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            Order Order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddres = request.ShippAddress,
                ShipCity = request.ShipCity,
                ShipCountry = request.ShipCountry,
                ShipPostalCode = request.ShipPostalCode,
                ShippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };
            OrderRepository.Create(Order);
            foreach(var Item in request.OrderDetails)
            {
                OrderDetailRepository.Create(
                    new OrderDetail
                    {
                        Order = Order,
                        ProducId = Item.ProducId,
                        UnitPrice = Item.UnitPrice,
                        Quantity = Item.Quantity
                    });
            }
            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new GeneralException("Error al crear la orden.", ex.Message);
            }
            return Order.Id;
        }
    }
}
