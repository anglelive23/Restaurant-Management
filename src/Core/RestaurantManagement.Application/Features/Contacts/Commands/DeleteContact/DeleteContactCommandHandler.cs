namespace RestaurantManagement.Application.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, bool>
    {
        #region Fields and Properties
        private readonly IContactRepository _repo;
        #endregion

        #region Constructors
        public DeleteContactCommandHandler(IContactRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new DeleteContactCommandValidator();
                await validator.ValidateAndThrowAsync(request, cancellationToken);

                var checkDelete = await _repo.RemoveContactAsync(request.Id);
                return checkDelete;
            }
            catch (Exception ex) when (ex is FluentValidation.ValidationException
                                    || ex is DataFailureException
                                    || ex is Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
