namespace RestaurantManagement.Application.Models.Dtos
{
    public class CreateSalesHeaderDto
    {
        public int? DiscountApplied { get; set; }
        public int TableId { get; set; }
        public int LocationId { get; set; }
        public List<CreateSalesLineDto>? SalesLines { get; set; }
        public int? StatusId { get; set; }
        public string CreatedBy { get; set; }
    }
}
