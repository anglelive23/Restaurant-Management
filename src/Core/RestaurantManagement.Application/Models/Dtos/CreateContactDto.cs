namespace RestaurantManagement.Application.Models.Dtos
{
    public class CreateContactDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Ocupation { get; set; }
        public string? PhoneNo1 { get; set; }
        public string? PhoneNo2 { get; set; }
        public string? PhoneNo3 { get; set; }
        public string? CreatedBy { get; set; }
    }
}
