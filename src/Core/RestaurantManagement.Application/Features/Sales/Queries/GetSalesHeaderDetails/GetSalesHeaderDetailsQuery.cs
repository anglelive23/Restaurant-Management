namespace RestaurantManagement.Application.Features.Sales.Queries.GetSalesHeaderDetails
{
    public class GetSalesHeaderDetailsQuery : IRequest<IQueryable<SalesHeader>>
    {
        public int Id { get; set; }
    }
}
