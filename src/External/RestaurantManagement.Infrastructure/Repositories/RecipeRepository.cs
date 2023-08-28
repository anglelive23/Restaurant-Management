namespace RestaurantManagement.Infrastructure.Repositories
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        #region Construcotrs
        public RecipeRepository(RestaurantContext context) : base(context) { }
        #endregion

        #region GET
        public IQueryable<Size> GetSizesForRecipe(int recipeId, Expression<Func<Size, bool>>? predicate = null)
        {
            try
            {
                IQueryable<Size> sizes = _context
                    .Sizes;

                if (predicate is not null)
                    sizes = sizes.Where(predicate);

                return sizes;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                        || ex is InvalidOperationException
                        || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }

        public IQueryable<Addon> GetAddonsForRecipe(int recipeId, Expression<Func<Addon, bool>>? predicate = null)
        {
            try
            {
                IQueryable<Addon> addons = _context
                    .Addons;

                if (predicate is not null)
                    addons = addons.Where(predicate);

                return addons;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                        || ex is InvalidOperationException
                        || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion

        #region POST
        public async Task<Recipe?> AddRecipeAsync(Recipe recipe)
        {
            try
            {
                if (IsExistingRecipe(recipe.Name))
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

        public async Task<Size?> AddSizeForRecipeAsync(int recipeId, Size size)
        {
            try
            {
                var recipe = await GetByIdAsync(recipeId);

                if (recipe == null)
                    return null;

                size.RecipeId = recipeId;
                _context.Sizes.Add(size);
                await _context.SaveChangesAsync();

                return size;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }

        public async Task<Addon?> AddAddonForRecipeAsync(int recipeId, Addon addon)
        {
            try
            {
                var recipe = await GetByIdAsync(recipeId);

                if (recipe == null)
                    return null;

                addon.RecipeId = recipeId;
                _context.Addons.Add(addon);
                await _context.SaveChangesAsync();

                return addon;
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
        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            try
            {
                _context.Update(recipe);
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

        public async Task<Addon?> UpdateAddonForRecipeAsync(int recipeId, int addonId, Addon addon)
        {
            try
            {
                var recipe = await GetByIdAsync(recipeId);
                if (recipe == null)
                    return null;

                var currentAddon = await _context
                    .Addons
                    .FirstOrDefaultAsync(a => a.Id == addonId);

                if (currentAddon is null)
                    return null;

                addon.Id = currentAddon.Id;
                addon.RecipeId = currentAddon.RecipeId;
                addon.CreatedBy = currentAddon.CreatedBy;
                addon.CreatedDate = currentAddon.CreatedDate;
                addon.IsActive = currentAddon.IsActive;
                addon.IsDeleted = currentAddon.IsDeleted;

                _context.Entry(currentAddon).CurrentValues.SetValues(addon);
                _context.Update(currentAddon);
                await _context.SaveChangesAsync();
                return currentAddon;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                        || ex is InvalidOperationException
                        || ex is DbUpdateException
                        || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }

        public async Task<Size?> UpdateSizeForRecipeAsync(int recipeId, int sizeId, Size size)
        {
            try
            {
                var recipe = await GetByIdAsync(recipeId);

                if (recipe == null)
                    return null;

                var currentSize = await _context
                    .Sizes
                    .FirstOrDefaultAsync(a => a.Id == sizeId);

                if (currentSize is null)
                    return null;

                size.Id = currentSize.Id;
                size.RecipeId = currentSize.RecipeId;
                size.CreatedBy = currentSize.CreatedBy;
                size.CreatedDate = currentSize.CreatedDate;
                size.IsActive = currentSize.IsActive;
                size.IsDeleted = currentSize.IsDeleted;

                _context.Entry(currentSize).CurrentValues.SetValues(size);
                _context.Update(currentSize);
                await _context.SaveChangesAsync();
                return currentSize;
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
        //public async Task<Recipe?> PartUpdateRecipeAsync(int id, Delta<Recipe> recipe)
        //{
        //    try
        //    {
        //        var currentRecipe = await GetByIdAsync(id);

        //        if (currentRecipe == null)
        //            return null;

        //        recipe.Patch(currentRecipe);
        //        _context.Update(currentRecipe);
        //        await _context.SaveChangesAsync();

        //        return currentRecipe;
        //    }
        //    catch (Exception ex) when (ex is ArgumentNullException
        //                            || ex is InvalidOperationException
        //                            || ex is DbUpdateException
        //                            || ex is SqlException)
        //    {
        //        throw new DataFailureException(ex.Message);
        //    }
        //}
        #endregion

        #region DELETE
        public async Task<bool> RemoveRecipeAsync(int id)
        {
            try
            {
                var recipe = await GetByIdAsync(id);

                if (recipe == null)
                    return false;

                if (recipe.IsDeleted == true)
                    return true;

                recipe.IsDeleted = true;
                recipe.LastModifiedDate = DateTime.UtcNow;

                // bulk update sizes and addons and mark them as deleted
                await _context.Sizes
                   .Where(s => s.RecipeId == id)
                   .ExecuteUpdateAsync(u => u.SetProperty(p => p.IsDeleted, true));
                await _context.Addons
                    .Where(a => a.RecipeId == id)
                    .ExecuteUpdateAsync(u => u.SetProperty(p => p.IsDeleted, true));

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

        public async Task<bool> RemoveSizeForRecipeAsync(int recipeId, int sizeId)
        {
            try
            {
                var size = await _context.Sizes
                    .AnyAsync(a => a.Id == sizeId && a.RecipeId == recipeId && a.IsDeleted == false);

                if (size is false)
                    return false;

                _context.Sizes
                    .Where(s => s.Id == sizeId && s.RecipeId == recipeId && s.IsDeleted == false)
                    .ExecuteUpdate(p => p.SetProperty(p => p.IsDeleted, true));
                return true;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }

        public async Task<bool> RemoveAddonForRecipeAsync(int recipeId, int addonId)
        {
            try
            {
                var addon = await _context.Addons
                    .AnyAsync(a => a.Id == addonId && a.RecipeId == recipeId && a.IsDeleted == false);

                if (addon is false)
                    return false;

                _context.Addons
                    .Where(s => s.Id == addonId && s.RecipeId == recipeId && s.IsDeleted == false)
                    .ExecuteUpdate(p => p.SetProperty(p => p.IsDeleted, true));
                return true;
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
        public bool IsExistingRecipe(string name)
        {
            return _context
                    .Recipes
                    .Any(a => a.Name == name && a.IsDeleted == false);
        }
        #endregion
    }
}
