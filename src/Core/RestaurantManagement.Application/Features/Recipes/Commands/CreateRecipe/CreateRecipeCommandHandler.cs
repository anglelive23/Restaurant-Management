namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Recipe?>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public CreateRecipeCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Recipe?> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRecipeCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validatorResult);

            var recipe = request.Adapt<Recipe>();
            recipe = await _repo.AddRecipeAsync(recipe);

            return recipe;
        }
        #endregion
    }
}
