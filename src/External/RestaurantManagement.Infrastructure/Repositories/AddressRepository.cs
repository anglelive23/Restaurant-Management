namespace RestaurantManagement.Infrastructure.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        #region Constrcutors
        public AddressRepository(RestaurantContext context) : base(context) { }
        #endregion

        #region POST
        public async Task<Address> AddAddressAsync(Address address)
        {
            try
            {
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                return address;
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
        public async Task<Address?> UpdateAddressAsync(int id, Address address)
        {
            try
            {
                var currentAddress = await GetByIdAsync(id);

                if (currentAddress == null)
                    return null;

                address.Id = currentAddress.Id;
                address.IsActive = currentAddress.IsActive;
                address.IsDeleted = currentAddress.IsDeleted;
                _context.Entry(currentAddress).CurrentValues.SetValues(address);
                _context.Update(currentAddress);
                await _context.SaveChangesAsync();

                return currentAddress;
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
        public async Task<bool> RemoveAddressAsync(int id)
        {
            try
            {
                var address = await GetByIdAsync(id);

                if (address == null)
                    return false;

                if (address.IsDeleted == true)
                    return true;

                address.IsDeleted = true;
                address.LastModifiedDate = DateTime.UtcNow;
                _context.Update(address);

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
