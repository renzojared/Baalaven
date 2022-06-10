using Baalaven.Presenters;
using Baalaven.Presenters.MakePaymentsDTO;
using Baalaven.UseCasesDTOs.MakePayment;
using Baalaven.UseCasesPorts.MakePayment;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Baalaven.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PaymentController
    {
        readonly IMakePaymentInputPort InputPort;
        readonly IMakePaymentOutputPort OutputPort;

        public PaymentController(IMakePaymentInputPort inputPort, IMakePaymentOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }
        [HttpPost("make-payment")]
        [ProducesResponseType(typeof(MakePaymentOutputPort), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]

        public async Task<MakePaymentsOutput> MakePayment(MakePaymentParams makePaymentParams)
        {
            await InputPort.Handle(makePaymentParams);
            var Presenter = OutputPort as MakePaymentsPresenter;
            return Presenter.Content;
        }
    }
}
