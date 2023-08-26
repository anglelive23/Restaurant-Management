namespace RestaurantManagement.Infrastructure.Repositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        #region Constructors
        public ImageRepository(RestaurantContext context) : base(context) { }
        #endregion

        #region POST
        public async Task<Image> AddImageAsync(Image image)
        {
            try
            {
                _context.Images.Add(image);
                await _context.SaveChangesAsync();

                return image;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }

        #endregion

        #region PUT
        public async Task<Image?> UpdateImageAsync(int id, Image image)
        {
            try
            {
                var currentImage = await GetByIdAsync(id);

                if (currentImage == null)
                    return null;

                image.Id = currentImage.Id;
                image.IsActive = currentImage.IsActive;
                image.IsDeleted = currentImage.IsDeleted;
                _context.Entry(currentImage).CurrentValues.SetValues(image);
                _context.Update(currentImage);
                await _context.SaveChangesAsync();

                return currentImage;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion

        #region DELETE
        public async Task<bool> RemoveImageAsync(int id)
        {
            try
            {
                var image = await GetByIdAsync(id);

                if (image == null)
                    return false;

                if (image.IsDeleted == true)
                    return true;

                image.IsDeleted = true;
                image.LastModifiedDate = DateTime.UtcNow;
                _context.Update(image);

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion
    }
}
