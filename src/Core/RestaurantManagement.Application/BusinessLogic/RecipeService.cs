namespace RestaurantManagement.Application.BusinessLogic
{
    public class RecipeService : IRecipeService
    {
        #region Fields and Properties
        private readonly IExternalImageService _imageService;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IImageRepository _imageRepository;
        #endregion

        #region Constructors
        public RecipeService(
            IExternalImageService imageService,
            IRecipeRepository recipeRepository,
            IImageRepository imageRepository)
        {
            _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
            _recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
            _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
        }
        #endregion

        #region Interface Implementation
        public async Task<Recipe?> AddRecipeWithImageAsync(CreateRecipeDto recipeDto)
        {
            try
            {
                var imageSaver = await SaveRecipeImageAsync(recipeDto.Image, recipeDto.CreatedBy);

                var recipe = await AddRecipeAsync(new Recipe
                {
                    Name = recipeDto.Name,
                    Description = recipeDto.Description,
                    InitialPrice = recipeDto.InitialPrice,
                    Rate = recipeDto.Rate,
                    Discount = recipeDto.Discount,
                    ImageId = imageSaver.Id,
                    CategoryId = recipeDto.CategoryId,
                    IsOffer = recipeDto.IsOffer,
                    CreatedBy = recipeDto.CreatedBy
                });

                return recipe;
            }
            catch (Exception ex) when (ex is ApplicationException
                                    || ex is DataFailureException
                                    || ex is Exception)
            {
                throw;
            }
        }

        public async Task<Recipe?> UpdateRecipeWithImageAsync(int recipeId, UpdateRecipeDto recipeDto)
        {
            var currentRecipe = await _recipeRepository
                .GetByIdAsync(recipeId);

            if (currentRecipe == null)
                return null;

            await UpdateRecipeImageAsync(currentRecipe.ImageId!.Value, recipeDto.Image);

            currentRecipe.Name = recipeDto.Name;
            currentRecipe.Description = recipeDto.Description;
            currentRecipe.InitialPrice = recipeDto.InitialPrice;
            currentRecipe.Rate = recipeDto.Rate;
            currentRecipe.Discount = recipeDto.Discount;
            currentRecipe.CategoryId = recipeDto.CategoryId;
            currentRecipe.IsOffer = recipeDto.IsOffer;
            currentRecipe.LastModifiedBy = recipeDto.LastModifiedBy;


            await _recipeRepository.UpdateRecipeAsync(currentRecipe);

            return currentRecipe;
        }
        #endregion

        #region Helper Methods
        private async Task<Recipe?> AddRecipeAsync(Recipe recipe)
        {
            try
            {
                return await _recipeRepository.AddRecipeAsync(recipe);
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                throw;
            }
        }

        private async Task<Image> SaveRecipeImageAsync(IFormFile image, string createdBy)
        {
            var imageServerSaver = _imageService.SaveImageToServer(image, "Recipes");

            if (!imageServerSaver)
                throw new ApplicationException("Image saving to server failed!");

            return await _imageRepository
                .AddImageAsync(new Image { Path = image.FileName, CreatedBy = createdBy });
        }

        private async Task UpdateRecipeImageAsync(int imageId, IFormFile image)
        {
            var recipeImage = await _imageRepository
                .GetByIdAsync(imageId);

            _imageService.UpdateImageOnServer(image, "Recipes", recipeImage!.Path);
        }
        #endregion
    }
}
