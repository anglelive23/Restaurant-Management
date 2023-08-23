namespace RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipe
{
    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, Recipe?>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public UpdateRecipeCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Recipe?> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _repo.GetByIdAsync(request.Id);
            if (recipe == null)
                return null;
            var checkUpdate = await _repo.UpdateRecipeAsync(recipe.Id, recipe);
            return checkUpdate;
        }
        #endregion
    }
}
