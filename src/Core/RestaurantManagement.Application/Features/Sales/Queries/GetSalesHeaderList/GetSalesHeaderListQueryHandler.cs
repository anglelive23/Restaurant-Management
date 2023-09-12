namespace RestaurantManagement.Application.Features.Sales.Queries.GetSalesHeaderList
{
    public class GetSalesHeaderListQueryHandler : IRequestHandler<GetSalesHeaderListQuery, IQueryable<SalesHeader>>
    {
        #region Fields and Properties
        private readonly ISalesRepository _repo;
        #endregion

        #region Constructors
        public GetSalesHeaderListQueryHandler(ISalesRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<SalesHeader>> Handle(GetSalesHeaderListQuery request, CancellationToken cancellationToken)
        {
            var salesHeaders = _repo
                .GetAll(s => s.IsDeleted == false);
            return await Task.FromResult(salesHeaders);
        }
        #endregion
    }
}
