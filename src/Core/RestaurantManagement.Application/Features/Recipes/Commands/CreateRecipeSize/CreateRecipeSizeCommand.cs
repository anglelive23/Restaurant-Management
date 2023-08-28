namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipeSize
{
    public class CreateRecipeSizeCommand : IRequest<Size?>
    {
        public int Id { get; set; }
        public CreateSizeDto SizeDto { get; set; }
    }
}
