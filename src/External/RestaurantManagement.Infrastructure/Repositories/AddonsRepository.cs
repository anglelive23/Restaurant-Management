﻿namespace RestaurantManagement.Infrastructure.Repositories
{
    public class AddonsRepository : BaseRepository<Addon>, IAddonsRepository
    {
        #region Construcotrs
        public AddonsRepository(RestaurantContext context) : base(context) { }
        #endregion

        #region POST
        public async Task<Addon?> AddAddonsAsync(Addon addons)
        {
            try
            {
                if (IsExistingAddon(addons.Name))
                    return null;

                _context.Addons.Add(addons);
                await _context.SaveChangesAsync();

                return addons;
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
        public async Task<Addon?> UpdateAddonsAsync(int id, Addon addons)
        {
            try
            {
                var currentAddon = await GetByIdAsync(id);

                if (currentAddon == null)
                    return null;

                addons.Id = currentAddon.Id;
                addons.IsActive = currentAddon.IsActive;
                addons.IsDeleted = currentAddon.IsDeleted;
                _context.Entry(currentAddon).CurrentValues.SetValues(addons);
                _context.Update(currentAddon);
                await _context.SaveChangesAsync();

                return currentAddon;
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
        public async Task<bool> RemoveAddonAsync(int id)
        {
            try
            {
                var addon = await GetByIdAsync(id);

                if (addon == null)
                    return false;

                if (addon.IsDeleted == true)
                    return true;

                addon.IsDeleted = true;
                addon.LastModifiedDate = DateTime.UtcNow;
                _context.Update(addon);

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

        #region Helpers
        public bool IsExistingAddon(string name)
        {
            return _context
                .Addons
                .Any(a => a.Name == name && a.IsDeleted == false);
        }
        #endregion
    }
}
