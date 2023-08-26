namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeDetails
{
    public class GetRecipeDetailsQuery : IRequest<IQueryable<Recipe>>
    {
        public int Id { get; set; }
    }
}
