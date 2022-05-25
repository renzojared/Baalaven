using Baalaven.Presenters.GetAllOrdersDTO;
using Baalaven.UseCasesDTOs.GetAllOrders;
using Baalaven.UseCasesPorts.GetAllOrders;
using System.Linq;
using System.Threading.Tasks;

namespace Baalaven.Presenters
{
    public class GetAllOrdersPresenters : IGetAllOrdersOutputPort, IPresenter<GetAllOrdersOutput>
    {
        public GetAllOrdersOutput Content { get; private set; }

        public Task Handle(GetAllOrdersOutputPort output)
        {
            var orders = output.Orders
                .Select(s => new Order
                {
                    OrderDate = s.OrderDate,
                    ShipAddress = s.ShipAddress,
                    ShipCity = s.ShipCity,
                    ShipCountry = s.ShipCountry,
                    ShipPostalCode = s.ShipPostalCode,
                    DiscountType = s.DiscountType,
                    Discount = s.Discount,
                    shippingType = s.shippingType,
                    OrderDetails = s.OrderDetails
                        .Select(od => new OrderDetail
                        {
                            Product = od.Product,
                            UnitPrice = od.UnitPrice,
                            Quantity = od.Quantity
                        }).ToList()
                })
                .ToList();

            Content = new GetAllOrdersOutput()
            {
                Orders = orders
            };
            return Task.CompletedTask;
        }
    }
}
