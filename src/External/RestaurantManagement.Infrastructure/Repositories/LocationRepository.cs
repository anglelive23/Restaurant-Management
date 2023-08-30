namespace RestaurantManagement.Infrastructure.Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        #region Constructors
        public LocationRepository(RestaurantContext context)
            : base(context) { }
        #endregion

        #region POST
        public async Task<Location?> AddLocationAsync(Location location)
        {
            try
            {
                if (IsExistingLocation(location.Name))
                    return null;

                _context.Locations.Add(location);
                await _context.SaveChangesAsync();
                return location;
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
        public async Task<Location?> UpdateLocationAsync(int id, Location location)
        {
            try
            {
                var currentLocation = await GetByIdAsync(id);

                if (currentLocation == null)
                    return null;

                location.Id = currentLocation.Id;
                location.IsActive = currentLocation.IsActive;
                location.IsDeleted = currentLocation.IsDeleted;
                location.CreatedDate = currentLocation.CreatedDate;
                location.CreatedBy = currentLocation.CreatedBy;

                _context.Entry(currentLocation).CurrentValues.SetValues(location);
                _context.Update(currentLocation);
                await _context.SaveChangesAsync();

                return currentLocation;
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
        public async Task<bool> RemoveLocationAsync(int id)
        {
            try
            {
                var location = await GetByIdAsync(id);

                if (location == null)
                    return false;

                if (location.IsDeleted == true)
                    return true;

                location.IsDeleted = true;
                location.LastModifiedDate = DateTime.UtcNow;
                _context.Update(location);

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
        private bool IsExistingLocation(string name)
        {
            return _context.Locations
                .Any(l => l.Name == name && l.IsDeleted == false);
        }
        #endregion
    }
}
