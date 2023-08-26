namespace RestaurantManagement.Application.Features.Categories.Queries.GetCategoriesListQuery
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, IQueryable<Category>>
    {
        #region Fields and Properties
        private readonly ICategoryRepository _repo;
        #endregion

        #region Constructors
        public GetCategoriesListQueryHandler(ICategoryRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public Task<IQueryable<Category>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = _repo.GetAll();
            return Task.FromResult(categories);
        }
        #endregion
    }
}
