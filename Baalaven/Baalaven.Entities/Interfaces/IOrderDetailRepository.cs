using Baalaven.Entities.POCOEntities;
using Baalaven.Entities.Specifications;
using System.Collections.Generic;

namespace Baalaven.Entities.Interfaces
{
    public interface IOrderDetailRepository
    {
        void Create(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetOrdersDetailByEspecification(Specification<OrderDetail> specification);
    }
}
