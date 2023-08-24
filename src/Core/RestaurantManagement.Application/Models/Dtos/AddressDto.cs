namespace RestaurantManagement.Application.Models.Dtos
{
    public class AddressDto : AuditableEntity
    {
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
    }
}
