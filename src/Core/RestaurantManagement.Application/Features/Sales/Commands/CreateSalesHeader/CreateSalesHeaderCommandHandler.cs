namespace RestaurantManagement.Application.Features.Sales.Commands.CreateSalesHeader
{
    public class CreateSalesHeaderCommandHandler : IRequestHandler<CreateSalesHeaderCommand, SalesHeader>
    {
        #region Fields and Properties
        private readonly ISalesOrdersService _salesService;
        #endregion

        #region Constructors
        public CreateSalesHeaderCommandHandler(ISalesOrdersService salesService)
        {
            _salesService = salesService ?? throw new ArgumentNullException(nameof(salesService));
        }
        #endregion

        #region Interface Implementation
        public async Task<SalesHeader> Handle(CreateSalesHeaderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSalesHeaderCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);
            return await _salesService.AddSalesHeaderAsync(request.SalesHeaderDto);
        }
        #endregion
    }
}
