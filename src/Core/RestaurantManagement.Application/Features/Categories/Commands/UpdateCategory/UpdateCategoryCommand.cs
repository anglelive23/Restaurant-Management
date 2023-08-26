namespace RestaurantManagement.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Category?>
    {
        public int Id { get; set; }
        public UpdateCategoryDto CategoryDto { get; set; }
    }
}
