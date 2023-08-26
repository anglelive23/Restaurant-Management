namespace RestaurantManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category?>
    {
        #region Fields and Properties
        private readonly ICategoryService _categoryService;
        #endregion

        #region Constructors
        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }
        #endregion

        #region Interface Implementation
        public async Task<Category?> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var validator = new CreateCategoryCommandValidator();
                await validator.ValidateAndThrowAsync(request, cancellationToken);

                var checkAdd = await _categoryService
                    .AddCategoryWithImageAsync(new CreateCategoryDto
                    {
                        CreatedBy = request.CreatedBy,
                        Image = request.Image,
                        Name = request.Name
                    });

                return checkAdd;
            }
            catch (Exception ex) when (ex is FluentValidation.ValidationException
                                    || ex is DataFailureException
                                    || ex is Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
