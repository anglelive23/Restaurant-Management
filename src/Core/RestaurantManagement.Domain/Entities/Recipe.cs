using Microsoft.OData.ModelBuilder;

namespace RestaurantManagement.Domain.Entities;

public class Recipe : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal InitialPrice { get; set; }
    public int? Rate { get; set; }
    public int? Discount { get; set; }
    public Image? Image { get; set; }
    public int? ImageId { get; set; }
    [Contained]
    public List<Size>? Sizes { get; set; }
    [Contained]
    public List<Addon>? Addons { get; set; }
    public Category? Category { get; set; }
    public int? CategoryId { get; set; }
    public bool IsOffer { get; set; }
}
