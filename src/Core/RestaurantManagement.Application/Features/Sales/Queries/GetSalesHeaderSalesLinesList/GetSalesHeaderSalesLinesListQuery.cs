namespace RestaurantManagement.Application.Features.Sales.Queries.GetSalesHeaderSalesLinesList
{
    public class GetSalesHeaderSalesLinesListQuery : IRequest<IQueryable<SalesLine>>
    {
        public int Id { get; set; }
    }
}
