using Baalaven.UseCasesDTOs.GetAllOrders;
using FluentValidation;

namespace Baalaven.UseCases.GetAllOrders
{
    public class GetAllOrdersValidator : AbstractValidator<GetAllOrdersParams>
    {
        public GetAllOrdersValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().WithMessage("You must provide the client identifier");
        }
    }
}
