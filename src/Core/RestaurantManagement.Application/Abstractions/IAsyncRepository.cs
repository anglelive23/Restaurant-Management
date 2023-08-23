namespace RestaurantManagement.Application.Abstractions
{
    public interface IAsyncRepository<T> where T : class
    {
        #region GET
        IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null);
        Task<T?> GetByIdAsync(int id);
        #endregion

        #region DELETE
        //Task<bool> RemoveAsync(int id);
        #endregion
    }
}
