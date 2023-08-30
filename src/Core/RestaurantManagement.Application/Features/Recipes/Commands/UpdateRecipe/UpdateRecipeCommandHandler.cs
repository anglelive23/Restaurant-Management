namespace RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipe
{
    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, Recipe?>
    {
        #region Fields and Properties
        private readonly IRecipeService _recipeService;
        #endregion

        #region Constructors
        public UpdateRecipeCommandHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));
        }
        #endregion

        #region Interface Implementation
        public async Task<Recipe?> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRecipeCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkUpdate = await _recipeService
                .UpdateRecipeWithImageAsync(request.Id, request.RecipeDto);
            return checkUpdate;
        }
        #endregion
    }
}
