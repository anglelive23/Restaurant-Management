namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeAddonsList
{
    public class GetRecipeAddonsListQuery : IRequest<IQueryable<Addon>>
    {
        public int Id { get; set; }
    }
}
