namespace RestaurantManagement.API.Controllers
{
    [Route("api/odata")]
    public class AddonsController : ODataController
    {
        #region Fields and Properties
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public AddonsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region GET
        [HttpGet("addons")]
        [OutputCache(PolicyName = "Addons")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(200, Type = typeof(IQueryable<Addon>))]
        public async Task<IActionResult> GetAllAddons()
        {
            try
            {
                Log.Information("Starting controller Addons action GetAllAddons.");
                var addons = await _mediator
                    .Send(new GetAddonsListQuery());
                Log.Information("Returning all Addons to the caller.");
                return Ok(addons);
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is ValidationException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("addons({key})")]
        [OutputCache(PolicyName = "Addon")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(200, Type = typeof(Addon))]
        public async Task<IActionResult> GetAddonById(int key)
        {
            try
            {
                Log.Information("Starting controller Addons action GetAddonById.");
                var addon = await _mediator
                    .Send(new GetAddonDetailsQuery { Id = key });

                Log.Information("Returning Artist data to the caller.");
                return Ok(SingleResult.Create(addon));
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is InvalidOperationException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Post
        [HttpPost("addons")]
        [ProducesResponseType(201, Type = typeof(Addon))]
        public async Task<IActionResult> AddAddon([FromBody] AddonDto addonDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Addons action AddAddon.");
                var addon = await _mediator
                    .Send(new CreateAddonCommand { Addon = addonDto });

                if (addon is null)
                    return BadRequest("Addon already exists with same Name!");

                #region Cache Evict
                await cache.EvictByTagAsync("Addons", cancellationToken);
                #endregion

                Log.Information("Addon has been added.");
                return Created(addon);
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is ValidationException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Put
        [HttpPut("addons({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAddon(int key, [FromBody] UpdateAddonCommand updateAddonCommand, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Addons action UpdateAddon.");
                var currentAddon = await _mediator
                    .Send(updateAddonCommand);

                if (currentAddon == null)
                    return NotFound("Addon not found!");

                #region Cache Evict
                await cache.EvictByTagAsync("Addons", cancellationToken);
                #endregion

                Log.Information($"Addon with id: {key} has been updated.");
                return NoContent();
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("addons({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveAddon(int key, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Addons action RemoveAddon.");

                var currentAddon = await _mediator
                    .Send(new DeleteAddonCommand { Id = key });

                if (currentAddon is false)
                    return NotFound("Addon not found!");

                #region Cache Evict
                await cache.EvictByTagAsync("Addons", cancellationToken);
                #endregion

                Log.Information($"Addon with id: {key} has been marked as deleted.");
                return NoContent();
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is ValidationException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
