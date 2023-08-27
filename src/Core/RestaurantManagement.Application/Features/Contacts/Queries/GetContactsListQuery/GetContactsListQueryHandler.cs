namespace RestaurantManagement.Application.Features.Contacts.Queries.GetContactsListQuery
{
    public class GetContactsListQueryHandler : IRequestHandler<GetContactsListQuery, IQueryable<Contact>>
    {
        #region Fields and Properties
        private readonly IContactRepository _repo;
        #endregion

        #region Constructors
        public GetContactsListQueryHandler(IContactRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Contact>> Handle(GetContactsListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var contacts = _repo.GetAll(a => a.IsDeleted == false);
                return await Task.FromResult(contacts);
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
