namespace RestaurantManagement.Application.BusinessLogic
{
    public interface ICategoryService
    {
        Task<Category?> AddCategoryWithImageAsync(CreateCategoryDto categoryDto);
        Task<Category?> UpdateCategoryWithImageAsync(int categoryId, UpdateCategoryDto categoryDto);
    }
}
