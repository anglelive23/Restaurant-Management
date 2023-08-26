namespace RestaurantManagement.Application.Features.Categories.Queries.GetCategoryDetailsQuery
{
    public class GetCategoryDetailsQuery : IRequest<IQueryable<Category>>
    {
        public int Id { get; set; }
    }
}
