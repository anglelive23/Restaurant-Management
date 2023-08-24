namespace RestaurantManagement.Application.Features.Addresses.Queries.GetAddressesListQuery
{
    public class GetAddressesListQueryHandler : IRequestHandler<GetAddressesListQuery, IQueryable<Address>>
    {
        #region Fields and Properties
        private readonly IAddressRepository _repo;
        #endregion

        #region Constructors
        public GetAddressesListQueryHandler(IAddressRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Address>> Handle(GetAddressesListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var addresses = _repo.GetAll(a => a.IsDeleted == false);
                return await Task.FromResult(addresses);
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
