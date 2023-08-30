namespace RestaurantManagement.Application.Features.Locations.Queries.GetLocationsList
{
    public class GetLocationsListQueryHandler : IRequestHandler<GetLocationsListQuery, IQueryable<Location>>
    {
        #region Fields and Properties
        private readonly ILocationRepository _repo;
        #endregion

        #region Constructors
        public GetLocationsListQueryHandler(ILocationRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Location>> Handle(GetLocationsListQuery request, CancellationToken cancellationToken)
        {
            var locations = _repo.GetAll();
            return await Task.FromResult(locations);
        }
        #endregion
    }
}
