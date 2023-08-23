using Microsoft.AspNetCore.OData.Deltas;
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
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        #region Construcotrs
        public RecipeRepository(RestaurantContext context) : base(context) { }
        #endregion

        #region POST
        public async Task<Recipe?> AddRecipeAsync(Recipe recipe)
        {
            try
            {
                if (!IsUniqueRecipe(recipe.Name))
                    return null;

                _context.Recipes.Add(recipe);
                await _context.SaveChangesAsync();

                return recipe;
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
        public async Task<Recipe?> UpdateRecipeAsync(int id, Recipe recipe)
        {
            try
            {
                var currentRecipe = await GetByIdAsync(id);

                if (currentRecipe == null)
                    return null;

                recipe.Id = currentRecipe.Id;
                _context.Entry(currentRecipe).CurrentValues.SetValues(recipe);
                _context.Update(currentRecipe);
                await _context.SaveChangesAsync();

                return currentRecipe;
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

        #region PATCH
        public async Task<Recipe?> PartUpdateRecipeAsync(int id, Delta<Recipe> recipe)
        {
            try
            {
                var currentRecipe = await GetByIdAsync(id);

                if (currentRecipe == null)
                    return null;

                recipe.Patch(currentRecipe);
                _context.Update(currentRecipe);
                await _context.SaveChangesAsync();

                return currentRecipe;
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
        public async Task<bool> RemoveRecipeAsync(int id)
        {
            try
            {
                var recipe = await GetByIdAsync(id);

                if (recipe == null)
                    return false;

                recipe.IsDeleted = true;
                _context.Update(recipe);

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
        public bool IsUniqueRecipe(string name)
        {
            return _context
                    .Recipes
                    .Any(a => a.Name == name && a.IsDeleted == false);
        }
        #endregion
    }
}
