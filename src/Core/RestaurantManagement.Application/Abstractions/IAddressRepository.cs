namespace RestaurantManagement.Application.Abstractions
{
    public interface IAddressRepository : IAsyncRepository<Address>
    {
        #region POST
        Task<Address> AddAddressAsync(Address address);
        #endregion

        #region PUT
        Task<Address?> UpdateAddressAsync(int id, Address address);
        #endregion

        #region DELETE
        Task<bool> RemoveAddressAsync(int id);
        #endregion
    }
}
