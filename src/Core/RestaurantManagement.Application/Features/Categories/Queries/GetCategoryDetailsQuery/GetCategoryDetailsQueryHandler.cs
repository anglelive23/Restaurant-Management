namespace RestaurantManagement.Application.Features.Categories.Queries.GetCategoryDetailsQuery
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, IQueryable<Category>>
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
        public async Task<IQueryable<Category>> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCategoryDetailsQueryValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var category = _repo.GetAll(c => c.Id == request.Id && c.IsDeleted == false);
            return category;
        }
        #endregion
    }
}
