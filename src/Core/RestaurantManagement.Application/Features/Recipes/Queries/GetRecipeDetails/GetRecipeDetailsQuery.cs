namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeDetails
{
    public class GetRecipeDetailsQuery : IRequest<Recipe?>
    {
        public int Id { get; set; }
    }
}
