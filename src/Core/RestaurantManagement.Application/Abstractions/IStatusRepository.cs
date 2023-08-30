namespace RestaurantManagement.Application.Abstractions
{
    public interface IStatusRepository : IAsyncRepository<Status>
    {
        #region POST
        Task<Status?> AddStatusAsync(Status status);
        #endregion

        #region PUT
        Task<Status?> UpdateStatusAsync(int id, Status status);
        #endregion

        #region DELETE
        Task<bool> RemoveStatusAsync(int id);
        #endregion
    }
}
