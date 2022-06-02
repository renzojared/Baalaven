using Baalaven.UseCasesDTOs.MakePayment;
using FluentValidation;
using System.Linq;

namespace Baalaven.UseCases.Common.Validators
{
    public class MakePaymentValidator : AbstractValidator<MakePaymentParams>
    {
        public MakePaymentValidator()
        {
            RuleFor(mk => mk.OrderId).NotEmpty().WithMessage("Debe proporcionar el identificador de la orden.");
            RuleFor(mk => mk.PaymentDetails).Must(pd => pd != null && pd.Any()).WithMessage("Deben especificarse los datos del pago.");
        }
    }
}
