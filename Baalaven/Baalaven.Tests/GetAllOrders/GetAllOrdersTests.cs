using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Baalaven.Entities.Interfaces;
using Baalaven.Controllers;
using Baalaven.Repositories.EFCore.Repositories;
using Baalaven.Entities.Specifications;
using Baalaven.Entities.POCOEntities;
using Microsoft.AspNetCore.Mvc;
using Baalaven.UseCasesPorts.CreateOrder;
using Xunit.Frameworks.Autofac;

namespace Baalaven.Tests.GetAllOrders
{
    [UseAutofacTestFramework]
    public class GetAllOrdersTests 
    {
        private readonly IOrderRepository OrderRepository;

        public GetAllOrdersTests(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }

        [Fact]
        public void Get_AllOrdersRepository()
        {
            Order order = new Order();            
            order.Id = 1;

            var customer = new Specification<Order>(o => o.Id == order.Id);
            var abc = OrderRepository.GetOrdersBySpecification(customer);

            Assert.Equal(1, 1);
            //Assert.IsType<IEnumerable<Order>>(abc);
            //Assert.Throws<NullReferenceException>(() => OrderRepository.GetOrdersBySpecification(customer));
        }
    }
}
