using Baalaven.UseCasesDTOs.CreateOrder;
using System.Threading.Tasks;

namespace Baalaven.UseCasesPorts.CreateOrder
{
    public interface ICreateOrderInputPort
    {
        Task Handle(CreateOrderParams order);
    }
}
