namespace RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipeSize
{
    public class DeleteRecipeSizeCommand
        : IRequest<bool>
    {
        public int RecipeId { get; set; }
        public int SizeId { get; set; }
    }
}
