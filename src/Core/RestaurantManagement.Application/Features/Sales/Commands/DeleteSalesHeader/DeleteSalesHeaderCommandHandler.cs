namespace RestaurantManagement.Application.Features.Sales.Commands.DeleteSalesHeader
{
    public class DeleteSalesHeaderCommandHandler : IRequestHandler<DeleteSalesHeaderCommand, bool>
    {
        #region Fields and Properties
        private readonly ISalesRepository _repo;
        #endregion

        #region Constructors
        public DeleteSalesHeaderCommandHandler(ISalesRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(DeleteSalesHeaderCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSalesHeaderCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkDelete = await _repo
                .RemoveSalesHeaderAsync(request.Id);
            return checkDelete;
        }
        #endregion
    }
}
