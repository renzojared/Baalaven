using FluentValidation;

namespace Baalaven.UseCases.GetAllOrders
{
    public class GetAllOrdersValidator : AbstractValidator<GetAllOrdersInputPort>
    {
        public GetAllOrdersValidator()
        {
            RuleFor(c => c.RequestData.CustomerId).NotEmpty().WithMessage("You must provide the client identifier");
        }
    }
}
