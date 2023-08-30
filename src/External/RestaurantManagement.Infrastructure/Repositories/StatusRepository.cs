namespace RestaurantManagement.Infrastructure.Repositories
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        #region Constructors
        public StatusRepository(RestaurantContext context)
            : base(context) { }
        #endregion

        #region POST
        public async Task<Status?> AddStatusAsync(Status status)
        {
            try
            {
                if (IsExistingStatus(status.Name))
                    return null;

                _context.Statuses.Add(status);
                await _context.SaveChangesAsync();
                return status;
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
        public async Task<Status?> UpdateStatusAsync(int id, Status status)
        {
            try
            {
                var currentStatus = await GetByIdAsync(id);

                if (currentStatus == null)
                    return null;

                status.Id = currentStatus.Id;
                status.IsActive = currentStatus.IsActive;
                status.IsDeleted = currentStatus.IsDeleted;
                status.CreatedDate = currentStatus.CreatedDate;
                status.CreatedBy = currentStatus.CreatedBy;

                _context.Entry(currentStatus).CurrentValues.SetValues(status);
                _context.Update(currentStatus);
                await _context.SaveChangesAsync();

                return currentStatus;
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
        public async Task<bool> RemoveStatusAsync(int id)
        {
            try
            {
                var status = await GetByIdAsync(id);

                if (status == null)
                    return false;

                if (status.IsDeleted == true)
                    return true;

                status.IsDeleted = true;
                status.LastModifiedDate = DateTime.UtcNow;
                _context.Update(status);

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

        #region Helper Methods
        private bool IsExistingStatus(string name)
        {
            return _context.Statuses
                .Any(s => s.Name == name && s.IsDeleted == false);
        }
        #endregion
    }
}
