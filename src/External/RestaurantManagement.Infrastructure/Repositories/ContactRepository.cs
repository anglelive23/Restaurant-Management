namespace RestaurantManagement.Infrastructure.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        #region Constrcutors
        public ContactRepository(RestaurantContext context) : base(context) { }
        #endregion

        #region POST
        public async Task<Contact> AddContactAsync(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                return contact;
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
        public async Task<Contact?> UpdateContactAsync(int id, Contact contact)
        {
            try
            {
                var currentContact = await GetByIdAsync(id);

                if (currentContact == null)
                    return null;

                contact.Id = currentContact.Id;
                contact.IsActive = currentContact.IsActive;
                contact.IsDeleted = currentContact.IsDeleted;
                contact.CreatedBy = currentContact.CreatedBy;
                contact.CreatedDate = currentContact.CreatedDate;
                _context.Entry(currentContact).CurrentValues.SetValues(contact);
                _context.Update(currentContact);
                await _context.SaveChangesAsync();

                return currentContact;
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
        public async Task<bool> RemoveContactAsync(int id)
        {
            try
            {
                var contact = await GetByIdAsync(id);

                if (contact == null)
                    return false;

                if (contact.IsDeleted == true)
                    return true;

                contact.IsDeleted = true;
                contact.LastModifiedDate = DateTime.UtcNow;
                _context.Update(contact);

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
