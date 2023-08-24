namespace RestaurantManagement.Application.Models.Dtos
{
    public class AddonDto : AuditableEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? RecipeId { get; set; }
    }
}
