namespace RestaurantManagement.Application.Features.Categories.Queries.GetCategoryDetailsQuery
{
    public class GetCategoryDetailsQuery : IRequest<Category?>
    {
        public int Id { get; set; }
    }
}
