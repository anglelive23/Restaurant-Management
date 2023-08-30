namespace RestaurantManagement.Application.Features.Contacts.Queries.GetContactDetailsQuery
{
    public class GetContactDetailsQueryHandler : IRequestHandler<GetContactDetailsQuery, IQueryable<Contact>>
    {
        #region Fields and Properties
        private readonly IContactRepository _repo;
        #endregion

        #region Constructors
        public GetContactDetailsQueryHandler(IContactRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<IQueryable<Contact>> Handle(GetContactDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetContactDetailsQueryValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var contact = _repo.GetAll(a => a.Id == request.Id && a.IsDeleted == false);
            return contact;
        }
        #endregion
    }
}
