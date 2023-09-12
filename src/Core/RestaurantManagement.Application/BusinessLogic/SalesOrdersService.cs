namespace RestaurantManagement.Application.BusinessLogic
{
    public class SalesOrdersService : ISalesOrdersService
    {
        #region Fields and Properties
        private readonly IPriceCalculator _priceCalculator;
        private readonly ISalesRepository _salesRepository;
        #endregion

        #region Constructors
        public SalesOrdersService(IPriceCalculator priceCalculator, ISalesRepository salesRepository)
        {
            _priceCalculator = priceCalculator ?? throw new ArgumentNullException(nameof(priceCalculator));
            _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        }
        #endregion

        #region Interface Implementation
        public async Task<SalesHeader> AddSalesHeaderAsync(CreateSalesHeaderDto salesHeaderDto)
        {
            var salesHeader = salesHeaderDto.Adapt<SalesHeader>();
            var headerDiscount = salesHeader.DiscountApplied ?? 0;

            salesHeader.SalesPrice = _priceCalculator
                .CalculatePrice(salesHeader, headerDiscount);
            return await _salesRepository.AddSalesHeaderAsync(salesHeader);
        }
        #endregion
    }
}
