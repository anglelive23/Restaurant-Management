namespace RestaurantManagement.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<Address?>
    {
        public int Id { get; set; }
        public AddressDto Address { get; set; }
    }
}
