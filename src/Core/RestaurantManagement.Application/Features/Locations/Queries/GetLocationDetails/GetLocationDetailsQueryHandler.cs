namespace RestaurantManagement.Application.Features.Locations.Queries.GetLocationDetails
{
    public class GetLocationDetailsQueryHandler : IRequestHandler<GetLocationDetailsQuery, IQueryable<Location>>
    {
        #region Fields and Properties
        private readonly ILocationRepository _repo;
        #endregion

        #region Constructors
        public GetLocationDetailsQueryHandler(ILocationRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Location>> Handle(GetLocationDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetLocationDetailsQueryValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);
            var location = _repo
                .GetAll(r => r.Id == request.Id && r.IsDeleted == false);
            return location;
        }
        #endregion
    }
}
