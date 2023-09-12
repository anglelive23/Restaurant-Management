namespace RestaurantManagement.Application.Features.Sales.Commands.DeleteSalesHeader
{
    public class DeleteSalesHeaderCommandValidator : AbstractValidator<DeleteSalesHeaderCommand>
    {
        public DeleteSalesHeaderCommandValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
