namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeDetails
{
    internal class GetRecipeDetailsQueryHandler : IRequestHandler<GetRecipeDetailsQuery, IQueryable<Recipe>>
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
        public async Task<IQueryable<Recipe>> Handle(GetRecipeDetailsQuery request, CancellationToken cancellationToken)
        {
            var recipe = _repo.GetAll(r => r.Id == request.Id && r.IsDeleted == false);
            return await Task.FromResult(recipe);
        }
        #endregion
    }
}
