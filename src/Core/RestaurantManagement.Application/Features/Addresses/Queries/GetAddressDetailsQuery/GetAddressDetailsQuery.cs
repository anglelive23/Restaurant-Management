namespace RestaurantManagement.Application.Features.Addresses.Queries.GetAddressDetailsQuery
{
    public class GetAddressDetailsQuery : IRequest<IQueryable<Address>>
    {
        public int Id { get; set; }
    }
}
