using Baalaven.Presenters;
using Baalaven.Presenters.GetAllOrdersDTO;
using Baalaven.UseCasesDTOs.GetAllOrders;
using Baalaven.UseCasesPorts.GetAllOrders;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Baalaven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetOrdersByCustomerController
    {
        readonly IGetAllOrdersInputPort inputPort;
        readonly IGetAllOrdersOutputPort outputPort;

        public GetOrdersByCustomerController(IGetAllOrdersInputPort inputPort, 
            IGetAllOrdersOutputPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }
        [HttpPost]
        [ProducesResponseType(typeof(GetAllOrdersOutput), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("GetAllOrdersByCustomer")]
        public async Task<GetAllOrdersOutput> GetAllOrdersByCustomer(GetAllOrdersParams input)
        {
            await inputPort.Handle(input);
            var presenter = outputPort as GetAllOrdersPresenters;

            return presenter.Content;
        }
    }
}
