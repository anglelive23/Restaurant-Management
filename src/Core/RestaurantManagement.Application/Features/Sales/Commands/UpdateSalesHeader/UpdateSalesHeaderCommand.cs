namespace RestaurantManagement.Application.Features.Sales.Commands.UpdateSalesHeader
{
    public class UpdateSalesHeaderCommand : IRequest<SalesHeader?>
    {
        public int Id { get; set; }
        public UpdateSalesHeaderDto SalesHeaderDto { get; set; }
    }
}
