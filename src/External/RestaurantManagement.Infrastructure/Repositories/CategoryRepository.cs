using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Application.Abstractions;
using RestaurantManagement.Application.Exceptions;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        #region Construcotrs
        public CategoryRepository(RestaurantContext context) : base(context) { }
        #endregion

        #region POST
        public async Task<Category?> AddCategoryAsync(Category category)
        {
            try
            {
                if (IsExistingCateogry(category.Name))
                    return null;

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
        public async Task<Category?> UpdateCategoryAsync(int id, Category category)
        {
            try
            {
                var currentCategory = await GetByIdAsync(id);

                if (currentCategory == null)
                    return null;

                category.Id = currentCategory.Id;
                _context.Entry(currentCategory).CurrentValues.SetValues(category);
                _context.Update(currentCategory);
                await _context.SaveChangesAsync();

                return currentCategory;
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
