using Baalaven.UseCasesDTOs.GetAllOrders;
using System.Threading.Tasks;

namespace Baalaven.UseCasesPorts.GetAllOrders
{
    public interface IGetAllOrdersInputPort
    {
        Task Handle(GetAllOrdersParams getAllOrders);
    }
}