namespace RestaurantManagement.Domain.Entities;

public class Address : AuditableEntity
{
    public int Id { get; set; }
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
}
