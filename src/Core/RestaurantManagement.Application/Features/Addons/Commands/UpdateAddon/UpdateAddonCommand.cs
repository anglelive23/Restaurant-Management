namespace RestaurantManagement.Application.Features.Addons.Commands.UpdateAddon
{
    public class UpdateAddonCommand : IRequest<Addon?>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? RecipeId { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
