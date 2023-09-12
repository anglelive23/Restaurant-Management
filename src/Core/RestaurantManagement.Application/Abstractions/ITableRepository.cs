namespace RestaurantManagement.Application.Abstractions
{
    public interface ITableRepository : IAsyncRepository<Table>
    {
        #region POST
        Task<Table?> AddTableAsync(Table table);
        #endregion

        #region PUT
        Task<Table?> UpdateTableAsync(int id, Table table);
        #endregion

        #region DELETE
        Task<bool> RemoveTableAsync(int id);
        #endregion
    }
}
