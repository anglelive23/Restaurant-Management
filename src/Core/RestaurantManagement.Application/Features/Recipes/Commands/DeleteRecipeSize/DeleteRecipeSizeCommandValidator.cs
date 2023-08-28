namespace RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipeSize
{
    public class DeleteRecipeSizeCommandValidator
        : AbstractValidator<DeleteRecipeSizeCommand>
    {
        public DeleteRecipeSizeCommandValidator()
        {
            RuleFor(r => r.RecipeId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(r => r.SizeId)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
