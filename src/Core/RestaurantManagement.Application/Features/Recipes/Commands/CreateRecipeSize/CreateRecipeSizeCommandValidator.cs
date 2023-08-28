namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipeSize
{
    public class CreateRecipeSizeCommandValidator : AbstractValidator<CreateRecipeSizeCommand>
    {
        public CreateRecipeSizeCommandValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(s => s.SizeDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(s => s.SizeDto.Price)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .PrecisionScale(18, 2, true).WithMessage("{PropertyName} precision is 18 and scale is 2.");

            RuleFor(s => s.SizeDto.CreatedBy)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
