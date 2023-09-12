namespace RestaurantManagement.Application.Features.Sales.Commands.DeleteSalesHeader
{
    public class DeleteSalesHeaderCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
