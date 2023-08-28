namespace RestaurantManagement.Application.BusinessLogic
{
    public interface IRecipeService
    {
        Task<Recipe?> AddRecipeWithImageAsync(CreateRecipeDto recipeDto);
        Task<Recipe?> UpdateRecipeWithImageAsync(int recipeId, UpdateRecipeDto recipeDto);
    }
}
