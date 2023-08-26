namespace RestaurantManagement.Application.Abstractions
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        #region GET
        IQueryable<Category> GetCategories(Expression<Func<Category, bool>>? predicate = null);
        #endregion

        #region POST
        Task<Category> AddCategoryAsync(Category category);
        #endregion

        #region PUT
        Task<Category?> UpdateCategoryAsync(int id, Category category);
        #endregion

        #region DELETE
        Task<bool> RemoveCategoryAsync(int id);
        #endregion

        #region Helpers
        bool IsExistingCateogry(string name);
        #endregion
    }
}
