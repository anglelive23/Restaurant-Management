namespace RestaurantManagement.Application.Models.Dtos
{
    public class CreateLocationDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? County { get; set; }
        public string? Town { get; set; }
        public int SeatQty { get; set; }
        public string CreatedBy { get; set; }
    }
}
