namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeSizesList
{
    public class GetRecipeSizesListQuery : IRequest<IQueryable<Size>>
    {
        public int Id { get; set; }
    }
}
