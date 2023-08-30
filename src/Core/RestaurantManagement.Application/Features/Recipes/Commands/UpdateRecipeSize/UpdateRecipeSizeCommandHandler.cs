namespace RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipeSize
{
    public class UpdateRecipeSizeCommandHandler : IRequestHandler<UpdateRecipeSizeCommand, Size?>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public UpdateRecipeSizeCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Size?> Handle(UpdateRecipeSizeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRecipeSizeCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkUpdate = await _repo
                .UpdateSizeForRecipeAsync(request.RecipeId, request.SizeId, request.SizeDto.Adapt<Size>());
            return checkUpdate;
        }
        #endregion
    }
}
