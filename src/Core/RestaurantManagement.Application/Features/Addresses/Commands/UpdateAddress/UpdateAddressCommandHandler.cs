namespace RestaurantManagement.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Address?>
    {
        #region Fields and Properties
        private readonly IAddressRepository _repo;
        #endregion

        #region Constructors
        public UpdateAddressCommandHandler(IAddressRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Address?> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAddressCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkUpdate = await _repo.UpdateAddressAsync(request.Id, request.Address.Adapt<Address>());
            return checkUpdate;
        }
        #endregion
    }
}
