using Baalaven.UseCasesDTOs.GetPayments;
using System.Threading.Tasks;

namespace Baalaven.UseCasesPorts.MakePayment
{
    public interface IMakePaymentOutputPort
    {
        Task Handle(GetPaymentsOutputPort output);
    }
}
