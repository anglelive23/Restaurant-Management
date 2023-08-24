namespace RestaurantManagement.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Address>
    {
        #region Fields and Properties
        private readonly IAddressRepository _repo;
        #endregion

        #region Constructors
        public CreateAddressCommandHandler(IAddressRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Address> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CreateAddressCommandValidator();
                await validator.ValidateAndThrowAsync(request, cancellationToken);

                var checkAdd = await _repo.AddAddressAsync(request.Address.Adapt<Address>());
                return checkAdd;
            }
            catch (Exception ex) when (ex is FluentValidation.ValidationException
                                    || ex is DataFailureException)
            {
                throw;
            }
        }
        #endregion
    }
}
