namespace RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, bool>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public DeleteRecipeCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new DeleteRecipeCommandValidator();
                await validator.ValidateAndThrowAsync(request, cancellationToken);

                var checkDelete = await _repo.RemoveRecipeAsync(request.Id);
                return checkDelete;
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
