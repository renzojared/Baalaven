using Baalaven.Entities.Interfaces;
using Baalaven.Entities.POCOEntities;
using Baalaven.Repositories.EFCore.ContextData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
