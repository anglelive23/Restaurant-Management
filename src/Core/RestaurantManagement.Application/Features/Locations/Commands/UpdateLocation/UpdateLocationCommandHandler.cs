namespace RestaurantManagement.Application.Features.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Location?>
    {
        #region Fields and Properties
        private readonly ILocationRepository _repo;
        #endregion

        #region Constructors
        public UpdateLocationCommandHandler(ILocationRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Location?> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLocationCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkUpdate = await _repo
                .UpdateLocationAsync(request.Id, request.LocationDto.Adapt<Location>());
            return checkUpdate;
        }
        #endregion
    }
}
