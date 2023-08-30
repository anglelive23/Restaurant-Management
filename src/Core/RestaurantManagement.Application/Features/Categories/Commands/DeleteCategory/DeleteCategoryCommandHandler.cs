namespace RestaurantManagement.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        #region Fields and Properties
        private readonly ICategoryRepository _repo;
        #endregion

        #region Constructors
        public DeleteCategoryCommandHandler(ICategoryRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCategoryCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkDelete = await _repo.RemoveCategoryAsync(request.Id);
            return checkDelete;
        }
        #endregion
    }
}
