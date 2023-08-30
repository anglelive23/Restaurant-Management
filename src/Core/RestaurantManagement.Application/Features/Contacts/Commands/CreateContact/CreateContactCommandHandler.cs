namespace RestaurantManagement.Application.Features.Contacts.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Contact>
    {
        #region Fields and Properties
        private readonly IContactRepository _repo;
        #endregion

        #region Constructors
        public CreateContactCommandHandler(IContactRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Contact> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateContactCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkAdd = await _repo
                .AddContactAsync(request.ContactDto.Adapt<Contact>());

            return checkAdd;
        }
        #endregion
    }
}
