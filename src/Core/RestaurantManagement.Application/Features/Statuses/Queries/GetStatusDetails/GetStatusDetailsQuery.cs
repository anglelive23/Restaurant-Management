namespace RestaurantManagement.Application.Features.Statuses.Queries.GetStatusDetails
{
    public class GetStatusDetailsQuery : IRequest<IQueryable<Status>>
    {
        public int Id { get; set; }
    }
}
