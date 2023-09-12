namespace RestaurantManagement.API.Controllers
{
    [Route("api/odata")]
    public class SalesOrdersController : ODataController
    {
        #region Fields and Properties
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public SalesOrdersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region GET
        [HttpGet("salesorders")]
        [OutputCache(PolicyName = "SalesOrders")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<SalesHeader>))]
        public async Task<IActionResult> GetAllSalesOrders()
        {
            Log.Information("Starting controller SalesOrders action GetAllSalesOrders.");
            var salesOrders = await _mediator
                .Send(new GetSalesHeaderListQuery());
            Log.Information("Returning all Sales Orders to the caller.");
            return Ok(salesOrders);
        }

        [HttpGet("salesorders({key})")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SalesHeader))]
        public async Task<IActionResult> GetSalesOrderById(int key)
        {
            Log.Information("Starting controller SalesOrders action GetSalesOrderById.");
            var salesOrder = await _mediator
                .Send(new GetSalesHeaderDetailsQuery
                {
                    Id = key
                });

            Log.Information($"Returning Sales Order with id: {key} to the caller.");
            return Ok(SingleResult.Create(salesOrder));
        }

        [HttpGet("salesorders({key})/saleslines")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<SalesLine>))]
        public async Task<IActionResult> GetAllLinesForSalesOrder(int key)
        {
            Log.Information("Starting controller SalesOrders action GetAllLinesForSalesOrder.");
            var salesLines = await _mediator
                .Send(new GetSalesHeaderSalesLinesListQuery
                {
                    Id = key
                });

            Log.Information($"Returning all Sales Order: {key} Sales Lines to the caller.");
            return Ok(salesLines);
        }
        #endregion

        #region POST
        [HttpPost("salesorders")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SalesHeader))]
        public async Task<IActionResult> AddSalesOrder([FromBody] CreateSalesHeaderDto salesDto)
        {
            Log.Information("Starting controller SalesOrders action AddSalesOrder.");
            var salesHeader = await _mediator
                .Send(new CreateSalesHeaderCommand
                {
                    SalesHeaderDto = salesDto,
                });
            return Created(salesHeader);
        }
        #endregion

        #region PUT
        [HttpPut("salesorders({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateSalesOrder(int key, [FromBody] UpdateSalesHeaderDto salesHeaderDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller SalesOrders action UpdateSalesOrder.");

            var currentOrder = await _mediator
                .Send(new UpdateSalesHeaderCommand
                {
                    Id = key,
                    SalesHeaderDto = salesHeaderDto
                });

            if (currentOrder == null)
                return NotFound("Sales order not found!");

            await cache.EvictByTagAsync("SalesOrders", cancellationToken);

            Log.Information($"Sales Orders with id: {key} has been updated.");
            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("salesorders({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveSalesOrder(int key, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller SalesOrder action RemoveSalesOrder.");

            var currentOrder = await _mediator
                .Send(new DeleteSalesHeaderCommand
                {
                    Id = key
                });

            if (currentOrder is false)
                return NotFound("Sales order not found!");

            await cache.EvictByTagAsync("SalesOrders", cancellationToken);

            Log.Information($"Sales order with id: {key} has been marked as deleted.");
            return NoContent();
        }
        #endregion
    }
}
