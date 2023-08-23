namespace RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
