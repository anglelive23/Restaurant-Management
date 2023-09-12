namespace RestaurantManagement.Domain.Entities;

public class SalesLine : AuditableEntity
{
    public int Id { get; set; }
    public int Quantity { get; set; } = 1;
    public Recipe? Recipe { get; set; }
    public int RecipeId { get; set; }
    public int? SizeId { get; set; }
    public SalesHeader? SalesHeader { get; set; }
    public int SalesHeaderId { get; set; }
    public string? Note { get; set; }
}
