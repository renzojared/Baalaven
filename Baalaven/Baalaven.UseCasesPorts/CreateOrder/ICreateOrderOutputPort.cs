using System.Threading.Tasks;

namespace Baalaven.UseCasesPorts.CreateOrder
{
    public interface ICreateOrderOutputPort
    {
        Task Handle(int orderId);
    }
}
