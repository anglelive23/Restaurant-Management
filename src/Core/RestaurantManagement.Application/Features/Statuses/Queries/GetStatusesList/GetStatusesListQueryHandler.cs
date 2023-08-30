namespace RestaurantManagement.Application.Features.Statuses.Queries.GetStatusesList
{
    public class GetStatusesListQueryHandler : IRequestHandler<GetStatusesListQuery, IQueryable<Status>>
    {
        #region Fields and Properties
        private readonly IStatusRepository _repo;
        #endregion

        #region Constructors
        public GetStatusesListQueryHandler(IStatusRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Status>> Handle(GetStatusesListQuery request, CancellationToken cancellationToken)
        {
            var statuses = _repo.GetAll();
            return await Task.FromResult(statuses);
        }
        #endregion
    }
}
