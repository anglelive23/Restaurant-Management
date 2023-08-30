namespace RestaurantManagement.Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        #region Fields and Properties
        private readonly IAddressRepository _repo;
        #endregion

        #region Constructors
        public DeleteAddressCommandHandler(IAddressRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteAddressCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkDelete = await _repo.RemoveAddressAsync(request.Id);
            return checkDelete;
        }
        #endregion
    }
}
