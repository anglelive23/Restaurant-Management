namespace RestaurantManagement.Application.Features.Statuses.Commands.DeleteStatus
{
    public class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommand, bool>
    {
        #region Fields and Properties
        private readonly IStatusRepository _repo;
        #endregion

        #region Constructors
        public DeleteStatusCommandHandler(IStatusRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteStatusCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkDelete = await _repo
                .RemoveStatusAsync(request.Id);
            return checkDelete;
        }
        #endregion
    }
}
