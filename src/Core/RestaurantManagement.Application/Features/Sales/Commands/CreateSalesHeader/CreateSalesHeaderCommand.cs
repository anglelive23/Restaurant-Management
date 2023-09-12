namespace RestaurantManagement.Application.Features.Sales.Commands.CreateSalesHeader
{
    public class CreateSalesHeaderCommand : IRequest<SalesHeader>
    {
        public CreateSalesHeaderDto SalesHeaderDto { get; set; }
    }
}
