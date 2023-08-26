namespace RestaurantManagement.Application.Features.Categories.Queries.GetCategoryDetailsQuery
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, Category?>
    {
        #region Fields and Properties
        private readonly ICategoryRepository _repo;
        #endregion

        #region Constructors
        public GetCategoryDetailsQueryHandler(ICategoryRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Category?> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCategoryDetailsQueryValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var category = await _repo.GetByIdAsync(request.Id);
            return category;
        }
        #endregion
    }
}
