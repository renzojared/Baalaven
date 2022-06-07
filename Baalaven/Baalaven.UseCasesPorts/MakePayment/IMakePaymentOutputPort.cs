using Baalaven.UseCasesDTOs.MakePayment;
using System.Threading.Tasks;

namespace Baalaven.UseCasesPorts.MakePayment
{
    public interface IMakePaymentOutputPort
    {
        Task Handle(MakePaymentOutputPort output);
    }
}
