namespace RestaurantManagement.Application.Features.Locations.Queries.GetLocationDetails
{
    public class GetLocationDetailsQuery : IRequest<IQueryable<Location>>
    {
        public int Id { get; set; }
    }
}
