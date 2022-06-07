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
        public async Task<MakePaymentsOutput> MakePayment(MakePaymentParams makePaymentParams)
        {
            await InputPort.Handle(makePaymentParams);
            var Presenter = OutputPort as MakePaymentsPresenter;
            return Presenter.Content;
        }
    }
}
