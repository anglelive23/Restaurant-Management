namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommand : IRequest<Recipe?>
    {
        public CreateRecipeDto RecipeDto { get; set; }
    }
}
