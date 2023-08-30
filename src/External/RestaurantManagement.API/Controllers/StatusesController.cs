namespace RestaurantManagement.API.Controllers
{
    [Route("api/odata")]
    public class StatusesController : ODataController
    {
        #region Fields and Properties
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public StatusesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region GET
        [HttpGet("statuses")]
        [OutputCache(PolicyName = "Statuses")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<Status>))]
        public async Task<IActionResult> GetAllStatuses()
        {
            Log.Information("Starting controller Statuses action GetAllStatuses.");
            var statuses = await _mediator
                .Send(new GetStatusesListQuery());
            Log.Information("Returning all Statuses to the caller.");
            return Ok(statuses);
        }

        [HttpGet("statuses({key})")]
        [OutputCache(PolicyName = "Status")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status))]
        public async Task<IActionResult> GetStatusById(int key)
        {
            Log.Information("Starting controller Statuses action GetStatusById.");
            var status = await _mediator
                .Send(new GetStatusDetailsQuery
                {
                    Id = key
                });

            Log.Information("Returning Status data to the caller.");
            return Ok(SingleResult.Create(status));
        }
        #endregion

        #region POST
        [HttpPost("statuses")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Location))]
        public async Task<IActionResult> AddStatus([FromBody] CreateStatusDto statusDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Statuses action AddStatus.");
            var status = await _mediator
                .Send(new CreateStatusCommand
                {
                    StatusDto = statusDto
                });

            if (status is null)
                return BadRequest("Status with same name already exist on server!");

            await cache.EvictByTagAsync("Statuses", cancellationToken);
            Log.Information("Status has been added.");
            return Created(status);
        }
        #endregion

        #region PUT
        [HttpPut("statuses({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateStatus(int key, [FromBody] UpdateStatusDto statusDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Statuses action UpdateStatus.");
            var currentStatus = await _mediator
                .Send(new UpdateStatusCommand
                {
                    Id = key,
                    StatusDto = statusDto
                });

            if (currentStatus is null)
                return NotFound("Status not found!");

            await cache.EvictByTagAsync("Statuses", cancellationToken);
            Log.Information($"Status with id: {key} has been updated.");
            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("statuses({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveStatus(int key, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Statuses action RemoveStatus.");

            var currentStatus = await _mediator
                .Send(new DeleteStatusCommand
                {
                    Id = key
                });

            if (currentStatus is false)
                return NotFound("Status not found!");

            await cache.EvictByTagAsync("Statuses", cancellationToken);
            Log.Information($"Status with id: {key} has been marked as deleted.");
            return NoContent();
        }
        #endregion
    }
}
