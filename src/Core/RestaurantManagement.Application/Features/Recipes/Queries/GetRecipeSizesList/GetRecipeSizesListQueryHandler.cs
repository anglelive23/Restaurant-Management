namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeSizesList
{
    public class GetRecipeSizesListQueryHandler : IRequestHandler<GetRecipeSizesListQuery, IQueryable<Size>>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public GetRecipeSizesListQueryHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Size>> Handle(GetRecipeSizesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetRecipeSizesListQueryValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var sizes = _repo
                .GetSizesForRecipe(request.Id, s => s.IsDeleted == false);
            return sizes;
        }
        #endregion
    }
}
