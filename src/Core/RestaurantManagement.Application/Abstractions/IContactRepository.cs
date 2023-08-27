namespace RestaurantManagement.Application.Abstractions
{
    public interface IContactRepository : IAsyncRepository<Contact>
    {
        #region POST
        Task<Contact> AddContactAsync(Contact contact);
        #endregion

        #region PUT
        Task<Contact?> UpdateContactAsync(int id, Contact contact);
        #endregion

        #region DELETE
        Task<bool> RemoveContactAsync(int id);
        #endregion
    }
}
