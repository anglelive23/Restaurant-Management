namespace RestaurantManagement.Application.Features.Sales.Commands.UpdateSalesHeader
{
    public class UpdateSalesHeaderCommandHandler : IRequestHandler<UpdateSalesHeaderCommand, SalesHeader?>
    {
        #region Fields and Properties
        private readonly ISalesRepository _repo;
        #endregion

        #region Constructors
        public UpdateSalesHeaderCommandHandler(ISalesRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<SalesHeader?> Handle(UpdateSalesHeaderCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSalesHeaderCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkUpdate = await _repo
                .UpdateSalesHeaderAsync(request.Id, request.SalesHeaderDto);
            return checkUpdate;
        }
        #endregion
    }
}
