using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baalaven.Entities.POCOEntities;
using Xunit;
using Baalaven.Entities.Interfaces;
using System.IO;

namespace Baalaven.Tests.CreateOrder
{
    public class CreateOrderTests
    {

        readonly IOrderRepository OrderRepository;
        [Fact]
        public void Add_NewOrder()
        {            
            Order order = new Order { };
            //OrderRepository.Create(order);
            Assert.Throws<NullReferenceException>(() => OrderRepository.Create(order));
        }

        [Fact]
        public void Add_NewSum()
        {
            int uno = 1;
            int dos = 1;
            Assert.Equal(uno, dos);
        }

    }
}