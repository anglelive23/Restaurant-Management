namespace RestaurantManagement.Application.Models.Dtos
{
    public class UpdateSalesHeaderDto
    {
        public int TableId { get; set; }
        public int StatusId { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
