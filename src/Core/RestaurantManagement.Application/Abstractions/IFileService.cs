namespace RestaurantManagement.Application.Abstractions
{
    public interface IFileService
    {
        bool SaveImageToServer(IFormFile file, string subFolder);
    }
}
