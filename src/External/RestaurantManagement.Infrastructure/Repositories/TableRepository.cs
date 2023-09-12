namespace RestaurantManagement.Infrastructure.Repositories
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        #region Constructors
        public TableRepository(RestaurantContext context)
            : base(context) { }
        #endregion

        #region POST
        public async Task<Table?> AddTableAsync(Table table)
        {
            try
            {
                if (IsExistingTable(table.Name, table.TableNumber))
                    return null;

                _context.Tables.Add(table);
                await _context.SaveChangesAsync();
                return table;
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
        public async Task<Table?> UpdateTableAsync(int id, Table table)
        {
            try
            {
                var currentTable = await GetByIdAsync(id);

                if (currentTable == null)
                    return null;

                table.Id = currentTable.Id;
                table.IsActive = currentTable.IsActive;
                table.IsDeleted = currentTable.IsDeleted;
                table.CreatedDate = currentTable.CreatedDate;
                table.CreatedBy = currentTable.CreatedBy;

                _context.Entry(currentTable).CurrentValues.SetValues(table);
                _context.Update(currentTable);
                await _context.SaveChangesAsync();

                return currentTable;
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
        public async Task<bool> RemoveTableAsync(int id)
        {
            try
            {
                var table = await AnyMatchingTable(id);

                if (table is false)
                    return false;

                _context.Tables
                    .Where(t => t.Id == id && t.IsDeleted == false)
                    .ExecuteUpdate(p =>
                        p.SetProperty(p => p.IsDeleted, true)
                        .SetProperty(p => p.IsActive, false));

                return true;
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

        #region Helper Methods
        private bool IsExistingTable(string name, int tableNumber)
        {
            return _context.Tables
                .Any(s => s.Name.ToLower() == name.ToLower() && s.TableNumber == tableNumber && s.IsDeleted == false);
        }

        private async Task<bool> AnyMatchingTable(int id)
        {
            return await _context.Tables
                .AnyAsync(t => t.Id == id && t.IsDeleted == false);
        }
        #endregion
    }
}
