namespace RestaurantManagement.Application.Models.Dtos
{
    public class CreateSalesLineDto
    {
        public int Quantity { get; set; }
        public int RecipeId { get; set; }
        public int SizeId { get; set; }
        public string? Note { get; set; }
        public string CreatedBy { get; set; }
    }
}
