namespace RestaurantManagement.Application.Abstractions
{
    public interface IExternalImageService
    {
        bool SaveImageToServer(IFormFile file, string subFolder);
        void UpdateImageOnServer(IFormFile file, string subFolder, string path);
    }
}
