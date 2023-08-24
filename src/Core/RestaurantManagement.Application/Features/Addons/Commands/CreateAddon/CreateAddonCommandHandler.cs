namespace RestaurantManagement.Application.Features.Addons.Commands.CreateAddon
{
    public class CreateAddonCommandHandler : IRequestHandler<CreateAddonCommand, Addon?>
    {
        #region Fields and Properties
        private readonly IAddonsRepository _repo;
        #endregion

        #region Constructors
        public CreateAddonCommandHandler(IAddonsRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Addon?> Handle(CreateAddonCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAddonCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var addon = await _repo.AddAddonsAsync(request.Addon.Adapt<Addon>());
            return addon;
        }
        #endregion
    }
}
