namespace RestaurantManagement.Application.BusinessLogic
{
    public interface ISalesOrdersService
    {
        Task<SalesHeader> AddSalesHeaderAsync(CreateSalesHeaderDto salesHeaderDto);
    }
}
