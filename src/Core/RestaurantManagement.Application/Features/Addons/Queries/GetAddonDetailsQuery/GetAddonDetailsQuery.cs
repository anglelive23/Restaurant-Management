namespace RestaurantManagement.Application.Features.Addons.Queries.GetAddonDetailsQuery
{
    public class GetAddonDetailsQuery : IRequest<Addon?>
    {
        public int Id { get; set; }
    }
}
