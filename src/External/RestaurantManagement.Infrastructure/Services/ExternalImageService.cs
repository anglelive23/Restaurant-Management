﻿namespace RestaurantManagement.Infrastructure.Services
{
    public class ExternalImageService : IExternalImageService
    {
        #region Interface Implementation
        public bool SaveImageToServer(IFormFile file, string subFolder)
        {
            if (file == null || file.Length == 0)
                return true;

            if (!file.ContentType.StartsWith("image/"))
                return false;

            try
            {
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", subFolder);

                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                var outputPath = Path.Combine(directoryPath, file.FileName);
                if (File.Exists(outputPath))
                    return false;

                using var stream = new FileStream(outputPath, FileMode.Create);
                file.CopyTo(stream);
                return true;
            }
            catch (IOException)
            {
                throw;
            }
        }

        public void UpdateImageOnServer(IFormFile file, string subFolder, string path)
        {

            try
            {
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", subFolder);

                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                var outputPath = Path.Combine(directoryPath, path);

                using var stream = new FileStream(outputPath, FileMode.Create);
                file.CopyTo(stream);
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
    #endregion
}
