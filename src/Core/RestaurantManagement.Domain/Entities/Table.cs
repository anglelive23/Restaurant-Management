namespace RestaurantManagement.Domain.Entities;

public class Table : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TableNumber { get; set; }
}
