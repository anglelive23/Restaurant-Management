namespace RestaurantManagement.Application.Abstractions
{
    public interface IRecipeRepository : IAsyncRepository<Recipe>
    {
        #region GET
        IQueryable<Size> GetSizesForRecipe(int recipeId, Expression<Func<Size, bool>>? predicate = null);
        IQueryable<Addon> GetAddonsForRecipe(int recipeId, Expression<Func<Addon, bool>>? predicate = null);
        #endregion

        #region POST
        Task<Recipe?> AddRecipeAsync(Recipe recipe);
        Task<Size?> AddSizeForRecipeAsync(int recipeId, Size size);
        Task<Addon?> AddAddonForRecipeAsync(int recipeId, Addon addon);
        #endregion

        #region PUT
        Task UpdateRecipeAsync(Recipe recipe);
        Task<Addon?> UpdateAddonForRecipeAsync(int recipeId, int addonId, Addon addon);
        Task<Size?> UpdateSizeForRecipeAsync(int recipeId, int sizeId, Size size);
        #endregion

        #region Patch
        //Task<Recipe?> PartUpdateRecipeAsync(int id, Delta<Recipe> recipe);
        #endregion

        #region DELETE
        Task<bool> RemoveRecipeAsync(int id);
        Task<bool> RemoveSizeForRecipeAsync(int recipeId, int sizeId);
        Task<bool> RemoveAddonForRecipeAsync(int recipeId, int addonId);

        #endregion

        #region Helpers
        bool IsExistingRecipe(string name);
        #endregion
    }
}
