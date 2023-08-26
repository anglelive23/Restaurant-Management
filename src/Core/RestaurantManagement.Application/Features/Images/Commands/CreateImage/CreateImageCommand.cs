namespace RestaurantManagement.Application.Features.Images.Commands.CreateImage
{
    public class CreateImageCommand : IRequest<Image>
    {
        public string Path { get; set; }
        public string CreatedBy { get; set; }
    }
}
