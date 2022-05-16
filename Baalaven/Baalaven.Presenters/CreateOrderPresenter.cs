using Baalaven.UseCasesPorts.CreateOrder;
using System.Threading.Tasks;

namespace Baalaven.Presenters
{
    public class CreateOrderPresenter : ICreateOrderOutputPort, IPresenter<string>
    {
        public string Content { get; private set; }
        public Task Handle(int orderId)
        {
            Content = $"Order ID: {orderId}";
            return Task.CompletedTask;
        }
    }
}