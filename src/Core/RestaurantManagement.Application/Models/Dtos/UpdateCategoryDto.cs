namespace RestaurantManagement.Application.Models.Dtos
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
