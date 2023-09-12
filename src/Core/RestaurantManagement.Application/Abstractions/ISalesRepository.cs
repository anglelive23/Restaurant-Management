namespace RestaurantManagement.Application.Abstractions
{
    public interface ISalesRepository : IAsyncRepository<SalesHeader>
    {
        #region GET
        IQueryable<SalesLine> GetSalesLinesForSalesHeader(int headerId, Expression<Func<SalesLine, bool>>? predicate = null);
        #endregion

        #region POST
        Task<SalesHeader> AddSalesHeaderAsync(SalesHeader salesHeader);
        #endregion

        #region PUT
        Task<SalesHeader?> UpdateSalesHeaderAsync(int id, UpdateSalesHeaderDto salesHeaderDto);
        #endregion

        #region DELETE
        Task<bool> RemoveSalesHeaderAsync(int id);
        #endregion
    }
}
