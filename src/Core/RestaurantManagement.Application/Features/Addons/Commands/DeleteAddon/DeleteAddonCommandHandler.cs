namespace RestaurantManagement.Application.Features.Addons.Commands.DeleteAddon
{
    public class DeleteAddonCommandHandler : IRequestHandler<DeleteAddonCommand, bool>
    {
        #region Fields and Properties
        private readonly IAddonsRepository _repo;
        #endregion

        #region Constructors
        public DeleteAddonCommandHandler(IAddonsRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(DeleteAddonCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteAddonCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var checkDelete = await _repo.RemoveAddonAsync(request.Id);

            return checkDelete;
        }
        #endregion
    }
}
