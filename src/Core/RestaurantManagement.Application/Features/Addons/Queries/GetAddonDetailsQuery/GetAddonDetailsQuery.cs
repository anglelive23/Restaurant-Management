namespace RestaurantManagement.Application.Features.Addons.Queries.GetAddonDetailsQuery
{
    public class GetAddonDetailsQuery : IRequest<IQueryable<Addon>?>
    {
        public int Id { get; set; }
    }
}
