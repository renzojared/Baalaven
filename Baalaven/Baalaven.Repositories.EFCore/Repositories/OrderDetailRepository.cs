using Baalaven.Entities.Interfaces;
using Baalaven.Entities.POCOEntities;
using Baalaven.Entities.Specifications;
using Baalaven.Repositories.EFCore.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Baalaven.Repositories.EFCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly BaalavenContext Context;

        public OrderDetailRepository(BaalavenContext context) => Context = context;

        public void Create(OrderDetail orderDetail)
        {
            Context.Add(orderDetail);
        }

        public IEnumerable<OrderDetail> GetOrdersDetailByEspecification(Specification<OrderDetail> specification)
        {
            var expressionDelegate = specification.Expression.Compile();
            return Context.OrderDetails
                .Include(i => i.Order)
                .Where(expressionDelegate);
        }
    }
}
