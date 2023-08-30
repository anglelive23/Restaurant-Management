namespace RestaurantManagement.Application.Features.Statuses.Commands.CreateStatus
{
    public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand, Status?>
    {
        #region Fields and Properties
        private readonly IStatusRepository _repo;
        #endregion

        #region Constructors
        public CreateStatusCommandHandler(IStatusRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Status?> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateStatusCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkAdd = await _repo
                .AddStatusAsync(request.StatusDto.Adapt<Status>());
            return checkAdd;
        }
        #endregion
    }
}
