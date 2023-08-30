namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeAddonsList
{
    public class GetRecipeAddonsListQueryHandler : IRequestHandler<GetRecipeAddonsListQuery, IQueryable<Addon>>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public GetRecipeAddonsListQueryHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Addon>> Handle(GetRecipeAddonsListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetRecipeAddonsListQueryValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var addons = _repo
                .GetAddonsForRecipe(request.Id, s => s.IsDeleted == false);
            return addons;
        }
        #endregion
    }
}
