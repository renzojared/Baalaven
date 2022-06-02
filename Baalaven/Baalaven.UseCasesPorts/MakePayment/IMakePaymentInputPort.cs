using Baalaven.UseCasesDTOs.MakePayment;
using System.Threading.Tasks;

namespace Baalaven.UseCasesPorts.MakePayment
{
    public interface IMakePaymentInputPort
    {
        Task Handle(MakePaymentParams payment);
    }
}
