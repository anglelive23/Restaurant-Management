namespace RestaurantManagement.API.Controllers
{
    [Route("api/odata")]
    public class AddressesController : ODataController
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
        [HttpGet("addresses")]
        [OutputCache(PolicyName = "Addresses")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<Address>))]
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

        [HttpGet("addresses({key})")]
        [OutputCache(PolicyName = "Address")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Address))]
        public async Task<IActionResult> GetAddressById(int key)
        {
            try
            {
                Log.Information("Starting controller Addresses action GetAddressById.");
                var address = await _mediator
                    .Send(new GetAddressDetailsQuery { Id = key });

                Log.Information("Returning Address data to the caller.");
                return Ok(SingleResult.Create(address));
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
        [HttpPost("addresses")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Address))]
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
                return Created(address);
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
        [HttpPut("addresses({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAddress(int key, [FromBody] AddressDto addressDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Addresses action UpdateAddress.");
                var currentAddress = await _mediator
                    .Send(new UpdateAddressCommand { Id = key, Address = addressDto });

                if (currentAddress == null)
                    return NotFound("Address not found!");

                #region Cache Evict
                await cache.EvictByTagAsync("Addresses", cancellationToken);
                #endregion

                Log.Information($"Address with id: {key} has been updated.");
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
        [HttpDelete("addresses({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveAddress(int key, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information("Starting controller Addresses action RemoveAddress.");

                var currentAddress = await _mediator
                    .Send(new DeleteAddressCommand { Id = key });

                if (currentAddress is false)
                    return NotFound("Address not found!");

                #region Cache Evict
                await cache.EvictByTagAsync("Addresses", cancellationToken);
                #endregion

                Log.Information($"Address with id: {key} has been marked as deleted.");
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
