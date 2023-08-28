namespace RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipe
{
    public class UpdateRecipeCommand : IRequest<Recipe?>
    {
        public int Id { get; set; }
        public UpdateRecipeDto RecipeDto { get; set; }
    }
}
