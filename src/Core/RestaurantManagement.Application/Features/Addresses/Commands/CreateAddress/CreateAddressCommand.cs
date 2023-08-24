namespace RestaurantManagement.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<Address>
    {
        public AddressDto Address { get; set; }
    }
}
