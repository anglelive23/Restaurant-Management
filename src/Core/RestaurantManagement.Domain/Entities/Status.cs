namespace RestaurantManagement.Domain.Entities;

public class Status : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}
