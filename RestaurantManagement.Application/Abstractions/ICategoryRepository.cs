using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Abstractions
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        #region POST
        Task<Category?> AddCategoryAsync(Category category);
        #endregion

        #region PUT
        Task<Category?> UpdateCategoryAsync(int id, Category category);
        #endregion
    }
}
