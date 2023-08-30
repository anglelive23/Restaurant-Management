namespace RestaurantManagement.Application.Abstractions
{
    public interface ILocationRepository : IAsyncRepository<Location>
    {
        #region POST
        Task<Location?> AddLocationAsync(Location location);
        #endregion

        #region PUT
        Task<Location?> UpdateLocationAsync(int id, Location location);
        #endregion

        #region DELETE
        Task<bool> RemoveLocationAsync(int id);
        #endregion
    }
}
