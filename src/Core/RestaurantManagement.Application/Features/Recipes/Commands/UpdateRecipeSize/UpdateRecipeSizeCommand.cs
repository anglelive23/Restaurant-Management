namespace RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipeSize
{
    public class UpdateRecipeSizeCommand : IRequest<Size?>
    {
        public int RecipeId { get; set; }
        public int SizeId { get; set; }
        public UpdateSizeDto SizeDto { get; set; }
    }
}
