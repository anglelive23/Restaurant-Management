namespace RestaurantManagement.Application.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Contact?>
    {
        #region Fields and Properties
        private readonly IContactRepository _repo;
        #endregion

        #region Constructors
        public UpdateContactCommandHandler(IContactRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Contact?> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateContactCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkUpdate = await _repo
                .UpdateContactAsync(request.Id, request.ContactDto.Adapt<Contact>());

            return checkUpdate;
        }
        #endregion
    }
}
