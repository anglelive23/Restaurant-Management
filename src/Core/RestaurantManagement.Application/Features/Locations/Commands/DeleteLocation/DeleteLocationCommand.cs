namespace RestaurantManagement.Application.Features.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
