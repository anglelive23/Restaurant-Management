namespace RestaurantManagement.Application.Features.Addresses.Queries.GetAddressDetailsQuery
{
    public class GetAddressDetailsQueryHandler : IRequestHandler<GetAddressDetailsQuery, IQueryable<Address>>
    {
        #region Fields and Properties
        private readonly IAddressRepository _repo;
        #endregion

        #region Constructors
        public GetAddressDetailsQueryHandler(IAddressRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Address>> Handle(GetAddressDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new GetAddressDetailsQueryValidator();
                await validator.ValidateAndThrowAsync(request, cancellationToken);
                var address = _repo.GetAll(a => a.Id == request.Id && a.IsDeleted == false);
                return address;
            }
            catch (Exception ex) when (ex is FluentValidation.ValidationException
                                    || ex is DataFailureException)
            {
                throw;
            }
        }
        #endregion
    }
}
