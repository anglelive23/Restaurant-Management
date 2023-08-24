namespace RestaurantManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        #region Fields and Properties
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateCategoryDto categoryDto)
        {
            try
            {
                // Save image to api server
                var imageSaver = await _mediator
                    .Send(new SaveImageCommand { File = categoryDto.Image, SubFolder = "Categories" });
                // Todo -> Rest of category post processes
                return Ok(imageSaver);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        #endregion
    }
}
