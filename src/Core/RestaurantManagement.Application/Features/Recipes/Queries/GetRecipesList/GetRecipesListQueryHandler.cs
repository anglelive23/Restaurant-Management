namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipesList
{
    public class GetRecipesListQueryHandler : IRequestHandler<GetRecipesListQuery, IQueryable<Recipe>>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public GetRecipesListQueryHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Recipe>> Handle(GetRecipesListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var recipes = _repo.GetAll();
                return await Task.FromResult(recipes);
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
