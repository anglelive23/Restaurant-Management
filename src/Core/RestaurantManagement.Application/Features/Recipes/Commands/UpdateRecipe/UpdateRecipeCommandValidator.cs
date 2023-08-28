namespace RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipe
{
    public class UpdateRecipeCommandValidator : AbstractValidator<UpdateRecipeCommand>
    {
        public UpdateRecipeCommandValidator()
        {
            RuleFor(r => r.RecipeDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(r => r.RecipeDto.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");


            RuleFor(r => r.RecipeDto.InitialPrice)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .PrecisionScale(18, 2, true).WithMessage("{PropertyName} precision is 18 and scale is 2.");

            RuleFor(r => r.RecipeDto.Rate)
                .InclusiveBetween(0, 5).WithMessage("{PropertyName} must be between 0 and 5.");

            RuleFor(r => r.RecipeDto.Image)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(r => r.RecipeDto.CategoryId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(r => r.RecipeDto.IsOffer)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(r => r.RecipeDto.LastModifiedBy)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
