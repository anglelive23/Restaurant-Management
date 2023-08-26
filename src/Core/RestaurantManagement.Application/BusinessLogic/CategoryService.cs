namespace RestaurantManagement.Application.BusinessLogic
{
    public class CategoryService : ICategoryService
    {
        #region Fields and Properties
        private readonly IExternalImageService _imageService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IImageRepository _imageRepository;
        #endregion

        #region Constructors
        public CategoryService(
            IExternalImageService imageServicec,
            ICategoryRepository categoryRepository,
            IImageRepository imageRepository)
        {
            _imageService = imageServicec ?? throw new ArgumentNullException(nameof(imageServicec));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
        }
        #endregion

        #region Interface Implementation
        public async Task<Category?> AddCategoryWithImageAsync(CreateCategoryDto categoryDto)
        {
            try
            {
                var imageSaver = await SaveCategoryImageAsync(categoryDto);

                var category = await AddCategoryAsync(new Category
                {
                    ImageId = imageSaver.Id,
                    CreatedBy = categoryDto.CreatedBy,
                    Name = categoryDto.Name
                });

                return category;
            }
            catch (Exception ex) when (ex is ApplicationException)
            {
                throw;
            }
        }

        public async Task<Category?> UpdateCategoryWithImageAsync(int categoryId, UpdateCategoryDto categoryDto)
        {
            var currentCategory = await _categoryRepository
                .GetByIdAsync(categoryId);

            if (currentCategory == null)
                return null;

            await UpdateCategoryImageAsync(currentCategory.ImageId, categoryDto.Image);

            currentCategory.LastModifiedBy = categoryDto.LastModifiedBy;
            currentCategory.Name = categoryDto.Name;

            await _categoryRepository.UpdateCategoryAsync(currentCategory);

            return currentCategory;
        }
        #endregion

        #region Helper Methods
        private async Task<Category?> AddCategoryAsync(Category category)
        {
            return await _categoryRepository.AddCategoryAsync(category);
        }

        private async Task<Image> SaveCategoryImageAsync(CreateCategoryDto categoryDto)
        {
            var imageServerSaver = _imageService
                .SaveImageToServer(categoryDto.Image, "Categories");

            if (!imageServerSaver)
                throw new ApplicationException("Failed to save image on server!");

            return await _imageRepository
                .AddImageAsync(new Image { CreatedBy = categoryDto.CreatedBy, Path = categoryDto.Image.FileName });
        }

        private async Task UpdateCategoryImageAsync(int imageId, IFormFile image)
        {
            var categoryImage = await _imageRepository
                .GetByIdAsync(imageId);

            _imageService.UpdateImageOnServer(image, "Categories", categoryImage!.Path);
        }
        #endregion
    }
}
