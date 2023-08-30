namespace RestaurantManagement.Application.Features.Statuses.Queries.GetStatusDetails
{
    public class GetStatusDetailsQueryHandler : IRequestHandler<GetStatusDetailsQuery, IQueryable<Status>>
    {
        #region Fields and Properties
        private readonly IStatusRepository _repo;
        #endregion

        #region Constructors
        public GetStatusDetailsQueryHandler(IStatusRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Status>> Handle(GetStatusDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetStatusDetailsQueryValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);
            var status = _repo
                .GetAll(r => r.Id == request.Id && r.IsDeleted == false);
            return status;
        }
        #endregion
    }
}
