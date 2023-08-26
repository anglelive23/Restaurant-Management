namespace RestaurantManagement.Application.Features.Addresses.Queries.GetAddressDetailsQuery
{
    public class GetAddressDetailsQuery : IRequest<Address?>
    {
        public int Id { get; set; }
    }
}
