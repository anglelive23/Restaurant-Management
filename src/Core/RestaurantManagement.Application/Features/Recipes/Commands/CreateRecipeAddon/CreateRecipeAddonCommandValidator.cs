namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipeAddon
{
    public class CreateRecipeAddonCommandValidator : AbstractValidator<CreateRecipeAddonCommand>
    {
        public CreateRecipeAddonCommandValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(s => s.AddonDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(s => s.AddonDto.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .PrecisionScale(18, 2, true).WithMessage("{PropertyName} precision is 18 and scale is 2.");

            RuleFor(s => s.AddonDto.CreatedBy)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
