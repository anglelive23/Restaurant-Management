namespace RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipeAddon
{
    public class UpdateRecipeAddonCommand : IRequest<Addon?>
    {
        public int RecipeId { get; set; }
        public int AddonId { get; set; }
        public UpdateAddonDto AddonDto { get; set; }
    }
}
