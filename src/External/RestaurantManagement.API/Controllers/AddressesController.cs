namespace RestaurantManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        #region Fields and Properties
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public AddressesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region GET
        [HttpGet]
        [OutputCache(PolicyName = "Addresses")]
        public async Task<IActionResult> GetAllAddresses()
        {
            try
            {
                Log.Information("Starting controller Addresses action GetAllAddresses.");
                var addresses = await _mediator
                    .Send(new GetAddressesListQuery());
                Log.Information("Returning all Addresses to the caller.");
                return Ok(addresses);
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
        [OutputCache(PolicyName = "Address")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            try
            {
                Log.Information("Starting controller Addresses action GetAddressById.");
                var address = await _mediator
                    .Send(new GetAddressDetailsQuery { Id = id });

                if (address == null)
                    return NotFound($"Could not found adress with id: {id}");

                Log.Information("Returning Address data to the caller.");
                return Ok(address);
            }
            catch (FluentValidation.ValidationException vex)
            {
                Log.Error($"{vex.Errors}");
                return StatusCode(500, vex.Errors);
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
        public async Task<IActionResult> AddAddress([FromBody] AddressDto addressDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Addresses action AddAddress.");
                var address = await _mediator
                    .Send(new CreateAddressCommand { Address = addressDto });

                #region Cache Evict
                await cache.EvictByTagAsync("Addresses", cancellationToken);
                #endregion

                Log.Information("Address has been added.");
                return Ok(address);
            }
            catch (FluentValidation.ValidationException vex)
            {
                Log.Error($"{vex.Errors}");
                return StatusCode(500, vex.Errors);
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
        public async Task<IActionResult> UpdateAddress(int id, [FromBody] AddressDto addressDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Addresses action UpdateAddress.");
                var currentAddress = await _mediator
                    .Send(new UpdateAddressCommand { Id = id, Address = addressDto });

                if (currentAddress == null)
                    return NotFound("Address not found!");

                #region Cache Evict
                await cache.EvictByTagAsync("Addresses", cancellationToken);
                #endregion

                Log.Information($"Address with id: {id} has been updated.");
                return NoContent();
            }
            catch (FluentValidation.ValidationException vex)
            {
                Log.Error($"{vex.Errors}");
                return StatusCode(500, vex.Errors);
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
        public async Task<IActionResult> RemoveAddress(int id, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Addresses action RemoveAddress.");

                var currentAddress = await _mediator
                    .Send(new DeleteAddressCommand { Id = id });

                if (currentAddress is false)
                    return NotFound("Address not found!");

                #region Cache Evict
                await cache.EvictByTagAsync("Addresses", cancellationToken);
                #endregion

                Log.Information($"Address with id: {id} has been marked as deleted.");
                return NoContent();
            }
            catch (FluentValidation.ValidationException vex)
            {
                Log.Error($"{vex.Errors}");
                return StatusCode(500, vex.Errors);
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
