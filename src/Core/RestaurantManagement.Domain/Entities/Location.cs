namespace RestaurantManagement.Domain.Entities;

public class Location : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? County { get; set; }
    public string? Town { get; set; }
    public int SeatQty { get; set; }
}
