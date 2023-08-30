namespace RestaurantManagement.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommand : IRequest<Location?>
    {
        public CreateLocationDto LocationDto { get; set; }
    }
}
