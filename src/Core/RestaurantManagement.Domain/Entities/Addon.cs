namespace RestaurantManagement.Domain.Entities;

public class Addon : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Recipe? Recipe { get; set; }
    public int? RecipeId { get; set; }
}
