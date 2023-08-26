namespace RestaurantManagement.Domain.Entities;

public class Category : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Image? Image { get; set; }
    public int ImageId { get; set; }
    public List<Recipe>? Recipes { get; set; }
}
