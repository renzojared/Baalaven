using Baalaven.UsesCases.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Baalaven.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator Mediator;
        public OrderController(IMediator mediator) => Mediator = mediator;
        [HttpPost("create-order")]
        public async Task<ActionResult<int>> CreateOrder(
            CreateOrderInputPort orderparams)
        {
            return await Mediator.Send(orderparams);
        }
    }
}
