namespace RestaurantManagement.Application.Features.Addons.Commands.CreateAddon
{
    public class CreateAddonCommand : IRequest<Addon?>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? RecipeId { get; set; }
        public string? CreatedBy { get; set; }
    }
}
