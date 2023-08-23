namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeDetails
{
    internal class GetRecipeDetailsQueryHandler : IRequestHandler<GetRecipeDetailsQuery, Recipe?>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public GetRecipeDetailsQueryHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Recipe?> Handle(GetRecipeDetailsQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _repo.GetByIdAsync(request.Id);
            return recipe;
        }
        #endregion
    }
}
