namespace RestaurantManagement.Infrastructure.Repositories
{
    public class SalesRepository : BaseRepository<SalesHeader>, ISalesRepository
    {
        #region Constructors
        public SalesRepository(RestaurantContext context) : base(context) { }
        #endregion

        #region GET
        public IQueryable<SalesLine> GetSalesLinesForSalesHeader(int headerId, Expression<Func<SalesLine, bool>>? predicate = null)
        {
            try
            {
                IQueryable<SalesLine> salesLines = _context
                    .SalesLines
                    .Where(s => s.SalesHeaderId == headerId);

                if (predicate is not null)
                    salesLines = salesLines.Where(predicate);

                return salesLines;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                        || ex is InvalidOperationException
                        || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion

        #region POST
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
        #endregion

        #region PUT
        public async Task<SalesHeader?> UpdateSalesHeaderAsync(int id, UpdateSalesHeaderDto salesHeaderDto)
        {
            try
            {
                var currentHeader = await GetByIdAsync(id);

                if (currentHeader == null)
                    return null;

                currentHeader.TableId = salesHeaderDto.TableId;
                currentHeader.StatusId = salesHeaderDto.StatusId;
                currentHeader.LastModifiedBy = salesHeaderDto.LastModifiedBy;
                _context.Update(currentHeader);
                await _context.SaveChangesAsync();

                return currentHeader;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion

        #region DELETE
        public async Task<bool> RemoveSalesHeaderAsync(int id)
        {
            try
            {
                var salesHeader = await GetByIdAsync(id);

                if (salesHeader == null)
                    return false;

                if (salesHeader.IsDeleted == true)
                    return true;

                salesHeader.IsDeleted = true;
                salesHeader.IsActive = false;
                salesHeader.LastModifiedDate = DateTime.UtcNow;
                _context.Update(salesHeader);

                await _context.SalesLines
                   .Where(s => s.SalesHeaderId == id)
                   .ExecuteUpdateAsync(u => u.SetProperty(p => p.IsDeleted, true));

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion
    }
}
