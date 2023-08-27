namespace RestaurantManagement.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category?>
    {
        #region Fields and Properties
        private readonly ICategoryService _categoryService;
        #endregion

        #region Constructors
        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }
        #endregion

        #region Interface Implementation
        public async Task<Category?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new UpdateCategoryCommandValidator();
                await validator.ValidateAndThrowAsync(request, cancellationToken);

                var checkUpdate = await _categoryService.UpdateCategoryWithImageAsync(request.Id, request.CategoryDto);

                return checkUpdate;
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is FluentValidation.ValidationException
                                    || ex is Exception)
            {
                throw;
            }

        }
        #endregion
    }
}
