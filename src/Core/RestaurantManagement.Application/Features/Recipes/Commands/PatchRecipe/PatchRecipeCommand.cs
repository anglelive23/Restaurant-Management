namespace RestaurantManagement.Application.Features.Recipes.Commands.PatchRecipe
{
    public class PatchRecipeCommand : IRequest<Recipe?>
    {
        public int Id { get; set; }
        public RecipePatchDto PatchDto { get; set; }
    }
}
