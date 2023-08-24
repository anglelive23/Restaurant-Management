namespace RestaurantManagement.Application.Features.Addons.Commands.CreateAddon
{
    public class CreateAddonCommand : IRequest<Addon?>
    {
        public AddonDto Addon { get; set; }
    }
}
