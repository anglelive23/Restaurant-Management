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

        #region Patch
        Task<Recipe?> PartUpdateRecipeAsync(int id, Delta<Recipe> recipe);
        #endregion

        #region DELETE
        Task<bool> RemoveRecipeAsync(int id);
        #endregion

        #region Helpers
        bool IsUniqueRecipe(string name);
        #endregion
    }
}
