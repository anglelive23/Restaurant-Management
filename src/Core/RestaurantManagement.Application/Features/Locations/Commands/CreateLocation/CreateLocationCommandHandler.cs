namespace RestaurantManagement.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Location?>
    {
        #region Fields and Properties
        private readonly ILocationRepository _repo;
        #endregion

        #region Constructors
        public CreateLocationCommandHandler(ILocationRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Location?> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLocationCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkAdd = await _repo
                .AddLocationAsync(request.LocationDto.Adapt<Location>());
            return checkAdd;
        }
        #endregion
    }
}
