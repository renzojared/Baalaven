using Baalaven.UseCasesDTOs.GetAllOrders;
using System.Threading.Tasks;

namespace Baalaven.UseCasesPorts.GetAllOrders
{
    public interface IGetAllOrdersOutputPort
    {
        Task Handler(GetAllOrdersOutputPort output);
    }
}
