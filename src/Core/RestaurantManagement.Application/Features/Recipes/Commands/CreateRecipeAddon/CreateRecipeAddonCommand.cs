namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipeAddon
{
    public class CreateRecipeAddonCommand : IRequest<Addon?>
    {
        public int Id { get; set; }
        public CreateAddonDto AddonDto { get; set; }
    }
}
