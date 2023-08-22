using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Abstractions
{
    public interface IRecipeRepository : IAsyncRepository<Recipe>
    {
        #region POST
        Task<Recipe?> AddRecipeAsync(Recipe recipe);
        #endregion

        #region PUT
        Task<Recipe?> UpdateRecipeAsync(int id, Recipe recipe);
        #endregion
    }
}
