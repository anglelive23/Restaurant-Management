namespace RestaurantManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Category?>
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string CreatedBy { get; set; }
    }
}
