namespace RestaurantManagement.API.Controllers
{
    [Route("api/odata")]
    public class CategoriesController : ODataController
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
        [HttpGet("categories")]
        [OutputCache(PolicyName = "Categories")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<Category>))]
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

        [HttpGet("categories({key})")]
        [OutputCache(PolicyName = "Category")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        public async Task<IActionResult> GetCategoryById(int key)
        {
            try
            {
                Log.Information("Starting controller Categories action GetCategoryById.");
                var category = await _mediator
                    .Send(new GetCategoryDetailsQuery { Id = key });

                Log.Information($"Returning category with id: {key} to the caller.");
                return Ok(SingleResult.Create(category));
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
        [HttpPost("categories")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Category))]
        public async Task<IActionResult> AddCategory([FromForm] CreateCategoryDto categoryDto, IOutputCacheStore cache, CancellationToken cancellationToken)
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

                #region Cache Evict
                await cache.EvictByTagAsync("Categories", cancellationToken);
                #endregion

                return Created(category);
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
