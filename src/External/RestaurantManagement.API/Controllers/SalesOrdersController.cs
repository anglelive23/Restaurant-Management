using RestaurantManagement.Application.Features.Sales.Commands.CreateSalesHeader;

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
    }
}
