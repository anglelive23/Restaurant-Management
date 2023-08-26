namespace RestaurantManagement.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        #region Construcotrs
        public CategoryRepository(RestaurantContext context) : base(context)
        {
        }
        #endregion

        #region POST
        public async Task<Category> AddCategoryAsync(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return category;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion

        #region PUT
        public async Task UpdateCategoryAsync(Category category)
        {
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion

        #region DELETE
        public async Task<bool> RemoveCategoryAsync(int id)
        {
            try
            {
                var category = await GetByIdAsync(id);

                if (category == null)
                    return false;

                if (category.IsDeleted == true)
                    return true;

                category.IsDeleted = true;
                category.LastModifiedDate = DateTime.UtcNow;
                _context.Update(category);

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion

        #region Helpers
        public bool IsExistingCateogry(string name)
        {
            return _context
                .Categories
                .Any(a => a.Name == name && a.IsDeleted == false);
        }
        #endregion
    }
}
