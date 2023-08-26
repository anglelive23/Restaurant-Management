namespace RestaurantManagement.Domain.Entities;

public class Image : AuditableEntity
{
    public int Id { get; set; }
    public string Path { get; set; }
}
