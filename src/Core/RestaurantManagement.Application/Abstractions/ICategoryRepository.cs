namespace RestaurantManagement.Application.Abstractions
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        #region POST
        Task<Category> AddCategoryAsync(Category category);
        #endregion

        #region PUT
        Task UpdateCategoryAsync(Category category);
        #endregion

        #region DELETE
        Task<bool> RemoveCategoryAsync(int id);
        #endregion

        #region Helpers
        bool IsExistingCateogry(string name);
        #endregion
    }
}
