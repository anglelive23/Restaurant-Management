namespace RestaurantManagement.Application.Models.Dtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string CreatedBy { get; set; }
    }
}
