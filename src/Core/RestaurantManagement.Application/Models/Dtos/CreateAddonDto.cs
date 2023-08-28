namespace RestaurantManagement.Application.Models.Dtos
{
    public class CreateAddonDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CreatedBy { get; set; }
    }
}
