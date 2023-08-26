namespace RestaurantManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public int ImageId { get; set; }
    }
}
