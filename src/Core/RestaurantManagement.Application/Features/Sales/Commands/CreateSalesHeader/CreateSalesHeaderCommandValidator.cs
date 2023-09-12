namespace RestaurantManagement.Application.Features.Sales.Commands.CreateSalesHeader
{
    public class CreateSalesHeaderCommandValidator : AbstractValidator<CreateSalesHeaderCommand>
    {
        public CreateSalesHeaderCommandValidator()
        {
            RuleFor(s => s.SalesHeaderDto.TableId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(s => s.SalesHeaderDto.LocationId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(s => s.SalesHeaderDto.CreatedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(s => s.SalesHeaderDto.SalesLines)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(s => s.SalesHeaderDto.SalesLines)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .ForEach(line =>
                {
                    line.SetValidator(new SalesLineValidator());
                });
        }
    }

    public class SalesLineValidator : AbstractValidator<CreateSalesLineDto>
    {
        public SalesLineValidator()
        {
            RuleFor(l => l.Quantity)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(l => l.RecipeId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(l => l.SizeId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(l => l.CreatedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
