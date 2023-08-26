﻿using Microsoft.EntityFrameworkCore;

namespace RestaurantManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddonsController : ControllerBase
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
        [HttpGet]
        [OutputCache(PolicyName = "Addons")]
        public async Task<IActionResult> GetAllAddons()
        {
            try
            {
                Log.Information("Starting controller Addons action GetAllAddons.");
                var addons = await _mediator
                    .Send(new GetAddonsListQuery());
                Log.Information("Returning all Addons to the caller.");
                Console.WriteLine($"{addons.ToQueryString()}");
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

        [HttpGet("{id}")]
        [OutputCache(PolicyName = "Addon")]
        public async Task<IActionResult> GetAddonById(int id)
        {
            try
            {
                Log.Information("Starting controller Addons action GetAddonById.");
                var addon = await _mediator
                    .Send(new GetAddonDetailsQuery { Id = id });
                if (addon is null)
                    return NotFound($"Could not found addon with id: {id}");

                Log.Information("Returning Artist data to the caller.");
                return Ok(addon);
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
        [HttpPost]
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
                return Ok(addon);
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddon(int id, [FromBody] UpdateAddonCommand updateAddonCommand, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
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

                Log.Information($"Addon with id: {id} has been updated.");
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAddon(int id, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Addons action RemoveAddon.");

                var currentAddon = await _mediator
                    .Send(new DeleteAddonCommand { Id = id });

                if (currentAddon is false)
                    return NotFound("Addon not found!");

                #region Cache Evict
                await cache.EvictByTagAsync("Addons", cancellationToken);
                #endregion

                Log.Information($"Addon with id: {id} has been marked as deleted.");
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
