namespace RestaurantManagement.Application.Features.Sales.Commands.UpdateSalesHeader
{
    public class UpdateSalesHeaderCommandValidator : AbstractValidator<UpdateSalesHeaderCommand>
    {
        public UpdateSalesHeaderCommandValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(s => s.SalesHeaderDto.StatusId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(s => s.SalesHeaderDto.TableId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(s => s.SalesHeaderDto.LastModifiedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
