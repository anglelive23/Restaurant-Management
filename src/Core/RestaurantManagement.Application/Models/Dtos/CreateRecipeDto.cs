namespace RestaurantManagement.Application.Models.Dtos
{
    public class CreateRecipeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal InitialPrice { get; set; }
        public int? Rate { get; set; }
        public int? Discount { get; set; }
        public IFormFile Image { get; set; }
        //public IList<CreateSizeDto>? Sizes { get; set; }
        //public IList<CreateAddonDto>? Addons { get; set; }
        public int? CategoryId { get; set; }
        public bool IsOffer { get; set; }
        public string CreatedBy { get; set; }
    }
}
