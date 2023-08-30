namespace RestaurantManagement.Application.Features.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand, Status?>
    {
        #region Fields and Properties
        private readonly IStatusRepository _repo;
        #endregion

        #region Constructors
        public UpdateStatusCommandHandler(IStatusRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Status?> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStatusCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkUpdate = await _repo
                .UpdateStatusAsync(request.Id, request.StatusDto.Adapt<Status>());
            return checkUpdate;
        }
        #endregion
    }
}
