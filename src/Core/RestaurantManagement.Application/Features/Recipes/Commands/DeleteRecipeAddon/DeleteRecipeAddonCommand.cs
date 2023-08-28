namespace RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipeAddon
{
    public class DeleteRecipeAddonCommand
        : IRequest<bool>
    {
        public int RecipeId { get; set; }
        public int AddonId { get; set; }
    }
}
