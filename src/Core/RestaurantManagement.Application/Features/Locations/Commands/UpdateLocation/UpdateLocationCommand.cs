namespace RestaurantManagement.Application.Features.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommand : IRequest<Location?>
    {
        public int Id { get; set; }
        public UpdateLocationDto LocationDto { get; set; }
    }
}
