namespace RestaurantManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        #region Fields and Properties
        private readonly ICategoryRepository _repo;
        #endregion

        #region Constructors
        public CreateCategoryCommandHandler(ICategoryRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var validator = new CreateCategoryCommandValidator();
                await validator.ValidateAndThrowAsync(request, cancellationToken);

                var checkAdd = await _repo.AddCategoryAsync(request.Adapt<Category>());
                return checkAdd;
            }
            catch (Exception ex) when (ex is FluentValidation.ValidationException
                                    || ex is DataFailureException)
            {
                throw;
            }
        }
        #endregion
    }
}
