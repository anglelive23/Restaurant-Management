namespace RestaurantManagement.Application.Features.Addons.Queries.GetAddonsListQuery
{
    public class GetAddonsListQueryHandler : IRequestHandler<GetAddonsListQuery, IQueryable<Addon>>
    {
        #region Fields and Properties
        private readonly IAddonsRepository _repo;
        #endregion

        #region Constructors
        public GetAddonsListQueryHandler(IAddonsRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Addon>> Handle(GetAddonsListQuery request, CancellationToken cancellationToken)
        {
            var addons = _repo.GetAll(a => a.IsDeleted == false);
            return await Task.FromResult(addons);
        }
        #endregion
    }
}
