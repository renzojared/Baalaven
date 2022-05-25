using Baalaven.Entities.Interfaces;
using Baalaven.UseCasesDTOs.GetAllOrders;
using Baalaven.UseCasesPorts.GetAllOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalaven.UseCases.GetAllOrders
{
    internal class GetAllOrdersInteractor : IGetAllOrdersInputPort
    {
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IProductRepository productRepository;
        public Task Handle(GetAllOrdersParams getAllOrders)
        {
            throw new NotImplementedException();
        }
    }
}
