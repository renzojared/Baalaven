using Baalaven.Presenters;
using Baalaven.UseCases.CreateOrder;
using Baalaven.UseCasesDTOs.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Baalaven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly IMediator Mediator;
        public OrderController(IMediator mediator) => Mediator = mediator;
        
        [HttpPost("create-order")]
        public async Task<string> CreateOrder(CreateOrderParams orderparams)
        {
            CreateOrderPresenter Presenter = new CreateOrderPresenter();
            await Mediator.Send(new CreateOrderInputPort(orderparams, Presenter));
            return Presenter.Content;
        }
    }
}