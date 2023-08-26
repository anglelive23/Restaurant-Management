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

        #region GET
        [HttpGet]
        [OutputCache(PolicyName = "Categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                Log.Information("Starting controller Categories action GetAllCategories.");
                var categories = await _mediator
                    .Send(new GetCategoriesListQuery());
                Log.Information("Returning all Categories to the caller.");
                return Ok(categories);
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [OutputCache(PolicyName = "Categories")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                Log.Information("Starting controller Categories action GetCategoryById.");
                var category = await _mediator
                    .Send(new GetCategoryDetailsQuery { Id = id });

                if (category is null)
                    return NotFound($"Could not found category with id: {id}");

                Log.Information($"Returning category with id: {id} to the caller.");
                return Ok(category);
            }
            catch (FluentValidation.ValidationException vex)
            {
                StringBuilder message = new StringBuilder();
                foreach (var error in vex.Errors)
                {
                    message.AppendLine(error.ErrorMessage);
                }
                Log.Error($"{message}");
                return StatusCode(500, $"An error occurred: {message}");
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] CreateCategoryDto categoryDto)
        {
            try
            {
                // Saving image to Server & DB
                var imageServerSaver = await _mediator
                    .Send(new SaveImageCommand { File = categoryDto.Image, SubFolder = "Categories" });
                if (imageServerSaver is false)
                    return BadRequest("There is already image with same name on server!");

                var imageDbSaver = await _mediator
                    .Send(new CreateImageCommand { CreatedBy = categoryDto.CreatedBy, Path = categoryDto.Image.FileName });
                if (imageDbSaver is null)
                    return BadRequest("Something went wrong while saving image to db!");

                // Saving Category
                var category = await _mediator
                    .Send(new CreateCategoryCommand { CreatedBy = categoryDto.CreatedBy, ImageId = imageDbSaver.Id, Name = categoryDto.Name });
                if (category is null)
                    return BadRequest("Something went wrong while saving category to db!");

                return Ok(category);
            }
            catch (FluentValidation.ValidationException vex)
            {
                StringBuilder message = new StringBuilder();
                foreach (var error in vex.Errors)
                {
                    message.AppendLine(error.ErrorMessage);
                }
                Log.Error($"{message}");
                return StatusCode(500, $"An error occurred: {message}");
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is Exception)
            {
                Log.Error($"{ex.Message}");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        #endregion
    }
}
