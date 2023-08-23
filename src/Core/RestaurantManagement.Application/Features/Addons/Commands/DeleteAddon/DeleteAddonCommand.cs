namespace RestaurantManagement.Application.Features.Addons.Commands.DeleteAddon
{
    public class DeleteAddonCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
