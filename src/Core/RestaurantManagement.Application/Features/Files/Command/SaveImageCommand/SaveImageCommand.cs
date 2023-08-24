namespace RestaurantManagement.Application.Features.Files.Command.SaveImageCommand
{
    public class SaveImageCommand : IRequest<bool>
    {
        public string SubFolder { get; set; }
        public IFormFile File { get; set; }
    }
}
