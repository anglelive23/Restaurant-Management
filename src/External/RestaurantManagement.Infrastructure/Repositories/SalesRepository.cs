namespace RestaurantManagement.Infrastructure.Repositories
{
    public class SalesRepository : BaseRepository<SalesHeader>, ISalesRepository
    {
        public SalesRepository(RestaurantContext context) : base(context) { }

        public async Task<SalesHeader> AddSalesHeaderAsync(SalesHeader salesHeader)
        {
            try
            {
                _context.SalesHeaders.Add(salesHeader);
                await _context.SaveChangesAsync();

                return salesHeader;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }

        public Task<SalesHeader?> UpdateSalesHeaderAsync(int id, SalesHeader salesHeader)
        {
            throw new NotImplementedException();
        }
    }
}
