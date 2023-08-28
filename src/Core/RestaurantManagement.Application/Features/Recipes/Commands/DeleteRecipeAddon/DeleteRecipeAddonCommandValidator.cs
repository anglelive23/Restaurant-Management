namespace RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipeAddon
{
    public class DeleteRecipeAddonCommandValidator
        : AbstractValidator<DeleteRecipeAddonCommand>
    {
        public DeleteRecipeAddonCommandValidator()
        {
            RuleFor(r => r.RecipeId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(r => r.AddonId)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
