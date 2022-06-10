using Baalaven.UseCasesPorts.MakePayment;
using Baalaven.UseCasesDTOs.MakePayment;
using Baalaven.Presenters.MakePaymentsDTO;
using System.Linq;
using System.Threading.Tasks;


namespace Baalaven.Presenters
{
    public class MakePaymentsPresenter : IMakePaymentOutputPort, IPresenter<MakePaymentsOutput>
    {
        public MakePaymentsOutput Content { get; private set; }

        public Task Handle(MakePaymentOutputPort ouput)
        {
            var payments = ouput.Payments
                .Select(s => new Payment
                {
                    OrderId = s.OrderId,
                    AmountPayable = s.AmountPayable,
                    PaymentStatus = s.PaymentStatus,
                    PaymentDetails = s.PaymentDetails
                    .Select(pd => new PaymentDetail
                    {
                        IdPaymentCard = pd.IdPaymentCard,
                        PaidAmount = pd.PaidAmount,
                        PaymentDate = pd.PaymentDate,
                        PaymentType = pd.PaymentType
                    }).ToList()
                })
                .ToList();

            Content = new MakePaymentsOutput()
            {
                Payments = payments
            };

            return Task.CompletedTask;
        }        
    }
}
