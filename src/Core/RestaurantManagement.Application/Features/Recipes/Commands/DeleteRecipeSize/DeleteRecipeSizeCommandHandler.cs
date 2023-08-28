namespace RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipeSize
{
    public class DeleteRecipeSizeCommandHandler
        : IRequestHandler<DeleteRecipeSizeCommand, bool>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public DeleteRecipeSizeCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(DeleteRecipeSizeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new DeleteRecipeSizeCommandValidator();
                await validator.ValidateAndThrowAsync(request, cancellationToken);

                var checkDelete = await _repo
                    .RemoveSizeForRecipeAsync(request.RecipeId, request.SizeId);
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
