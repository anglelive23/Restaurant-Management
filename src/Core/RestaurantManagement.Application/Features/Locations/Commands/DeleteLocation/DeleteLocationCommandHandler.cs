namespace RestaurantManagement.Application.Features.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, bool>
    {
        #region Fields and Properties
        private readonly ILocationRepository _repo;
        #endregion

        #region Constructors
        public DeleteLocationCommandHandler(ILocationRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteLocationCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkDelete = await _repo
                .RemoveLocationAsync(request.Id);
            return checkDelete;
        }
        #endregion
    }
}
