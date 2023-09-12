namespace RestaurantManagement.Application.Features.Sales.Queries.GetSalesHeaderDetails
{
    public class GetSalesHeaderDetailsQueryHandler : IRequestHandler<GetSalesHeaderDetailsQuery, IQueryable<SalesHeader>>
    {
        #region Fields and Properties
        private readonly ISalesRepository _repo;
        #endregion

        #region Constructors
        public GetSalesHeaderDetailsQueryHandler(ISalesRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<SalesHeader>> Handle(GetSalesHeaderDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSalesHeaderDetailsQueryValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);
            var salesHeader = _repo
                .GetAll(r => r.Id == request.Id && r.IsDeleted == false);
            return salesHeader;
        }
        #endregion
    }
}
