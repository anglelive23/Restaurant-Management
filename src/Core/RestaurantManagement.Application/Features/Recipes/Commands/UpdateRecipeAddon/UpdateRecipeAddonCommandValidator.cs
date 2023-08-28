namespace RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipeAddon
{
    public class UpdateRecipeAddonCommandValidator : AbstractValidator<UpdateRecipeAddonCommand>
    {
        public UpdateRecipeAddonCommandValidator()
        {
            RuleFor(r => r.RecipeId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(r => r.AddonId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(r => r.AddonDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(50).WithMessage("{PropertyName} has max length of 50");


            RuleFor(r => r.AddonDto.Price)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .PrecisionScale(18, 2, true).WithMessage("{PropertyName} precision is (18, 2)");

            RuleFor(r => r.AddonDto.LastModifiedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
