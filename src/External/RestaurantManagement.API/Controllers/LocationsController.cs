namespace RestaurantManagement.API.Controllers
{
    [Route("api/odata")]
    public class LocationsController : ODataController
    {
        #region Fields and Properties
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public LocationsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region GET
        [HttpGet("locations")]
        [OutputCache(PolicyName = "Locations")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<Location>))]
        public async Task<IActionResult> GetAllLocations()
        {
            Log.Information("Starting controller Locations action GetAllLocations.");
            var locations = await _mediator
                .Send(new GetLocationsListQuery());
            Log.Information("Returning all Locations to the caller.");
            return Ok(locations);
        }

        [HttpGet("locations({key})")]
        [OutputCache(PolicyName = "Location")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Location))]
        public async Task<IActionResult> GetLocationById(int key)
        {
            Log.Information("Starting controller Locations action GetLocationById.");
            var location = await _mediator
                .Send(new GetLocationDetailsQuery
                {
                    Id = key
                });

            Log.Information("Returning Location data to the caller.");
            return Ok(SingleResult.Create(location));
        }
        #endregion

        #region POST
        [HttpPost("locations")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Location))]
        public async Task<IActionResult> AddLocation([FromBody] CreateLocationDto locationDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Locations action AddLocation.");
            var location = await _mediator
                .Send(new CreateLocationCommand
                {
                    LocationDto = locationDto
                });

            if (location is null)
                return BadRequest("Location with same name already exist on server!");

            await cache.EvictByTagAsync("Locations", cancellationToken);
            Log.Information("Location has been added.");
            return Created(location);
        }
        #endregion

        #region PUT
        [HttpPut("locations({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateLocation(int key, [FromBody] UpdateLocationDto locationDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Locations action UpdateLocation.");
            var currentLocation = await _mediator
                .Send(new UpdateLocationCommand
                {
                    Id = key,
                    LocationDto = locationDto
                });

            if (currentLocation == null)
                return NotFound("Location not found!");

            await cache.EvictByTagAsync("Locations", cancellationToken);
            Log.Information($"Location with id: {key} has been updated.");
            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("locations({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveLocation(int key, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Locations action RemoveLocation.");

            var currentLocation = await _mediator
                .Send(new DeleteLocationCommand
                {
                    Id = key
                });

            if (currentLocation is false)
                return NotFound("Location not found!");

            await cache.EvictByTagAsync("Locations", cancellationToken);
            Log.Information($"Location with id: {key} has been marked as deleted.");
            return NoContent();
        }
        #endregion
    }
}
