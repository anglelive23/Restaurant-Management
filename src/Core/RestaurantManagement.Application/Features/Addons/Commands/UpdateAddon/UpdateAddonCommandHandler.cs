namespace RestaurantManagement.Application.Features.Addons.Commands.UpdateAddon
{
    public class UpdateAddonCommandHandler : IRequestHandler<UpdateAddonCommand, Addon?>
    {
        #region Fields and Properties
        private readonly IAddonsRepository _repo;
        #endregion

        #region Constructors
        public UpdateAddonCommandHandler(IAddonsRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Interface Implementation
        public async Task<Addon?> Handle(UpdateAddonCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAddonCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            try
            {
                var checkUpdate = await _repo
                    .UpdateAddonsAsync(request.Id, request.Adapt<Addon>());

                return checkUpdate;
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion
    }
}
