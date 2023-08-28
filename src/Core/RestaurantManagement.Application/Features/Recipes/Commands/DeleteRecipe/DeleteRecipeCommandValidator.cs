namespace RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommandValidator : AbstractValidator<DeleteRecipeCommand>
    {
        public DeleteRecipeCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
