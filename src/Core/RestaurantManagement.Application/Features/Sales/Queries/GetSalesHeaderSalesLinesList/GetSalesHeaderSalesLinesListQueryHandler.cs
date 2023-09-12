namespace RestaurantManagement.Application.Features.Sales.Queries.GetSalesHeaderSalesLinesList
{
    public class GetSalesHeaderSalesLinesListQueryHandler : IRequestHandler<GetSalesHeaderSalesLinesListQuery, IQueryable<SalesLine>>
    {
        #region Fields and Properties
        private readonly ISalesRepository _repo;
        #endregion

        #region Constructors
        public GetSalesHeaderSalesLinesListQueryHandler(ISalesRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<SalesLine>> Handle(GetSalesHeaderSalesLinesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSalesHeaderSalesLinesListQueryValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var salesLines = _repo
                .GetSalesLinesForSalesHeader(request.Id, s => s.IsDeleted == false);
            return salesLines;
        }
        #endregion
    }
}
