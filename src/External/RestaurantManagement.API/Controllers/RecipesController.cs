namespace RestaurantManagement.API.Controllers
{
    [Route("api/odata")]
    public class RecipesController : ODataController
    {
        #region Fields and Properties
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public RecipesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region GET
        [HttpGet("recipes")]
        [OutputCache(PolicyName = "Recipes")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<Recipe>))]
        public async Task<IActionResult> GetAllRecipes()
        {
            Log.Information("Starting controller Recipes action GetAllRecipes.");
            var categories = await _mediator
                .Send(new GetRecipesListQuery());
            Log.Information("Returning all Recipes to the caller.");
            return Ok(categories);
        }

        [HttpGet("recipes({key})")]
        [OutputCache(PolicyName = "Recipe")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Recipe))]
        public async Task<IActionResult> GetRecipeById(int key)
        {
            Log.Information("Starting controller Recipes action GetRecipeById.");
            var recipe = await _mediator
                .Send(new GetRecipeDetailsQuery
                {
                    Id = key
                });

            Log.Information($"Returning Recipe with id: {key} to the caller.");
            return Ok(SingleResult.Create(recipe));
        }

        [HttpGet("recipes({key})/sizes")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<Size>))]
        public async Task<IActionResult> GetAllSizesForRecipes(int key)
        {
            try
            {
                Log.Information("Starting controller Recipes action GetAllSizesForRecipes.");
                var sizes = await _mediator
                    .Send(new GetRecipeSizesListQuery
                    {
                        Id = key
                    });

                Log.Information($"Returning all recipe: {key} sizes to the caller.");
                return Ok(sizes);
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

        [HttpGet("recipes({key})/addons")]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 1000)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<Addon>))]
        public async Task<IActionResult> GetAllAddonsForRecipes(int key)
        {
            try
            {
                Log.Information("Starting controller Recipes action GetAllAddonsForRecipes.");
                var addons = await _mediator
                    .Send(new GetRecipeAddonsListQuery
                    {
                        Id = key
                    });

                Log.Information($"Returning all recipe: {key} addons to the caller.");
                return Ok(addons);
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

        #region POST
        [HttpPost("recipes")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Category))]
        public async Task<IActionResult> AddRecipe([FromForm] CreateRecipeDto recipeDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Recipes action AddRecipe.");
            var recipe = await _mediator
                .Send(new CreateRecipeCommand
                {
                    RecipeDto = recipeDto
                });

            if (recipe is null)
                return BadRequest("Recipe with same name exist on the server!");

            await cache.EvictByTagAsync("Recipes", cancellationToken);

            return Created(recipe);
        }

        [HttpPost("recipes({key})/sizes")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Size))]
        public async Task<IActionResult> AddSizeForRecipe(int key, [FromBody] CreateSizeDto sizeDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Recipes action AddSizeForRecipe.");
            var size = await _mediator
                .Send(new CreateRecipeSizeCommand
                {
                    Id = key,
                    SizeDto = sizeDto
                });

            if (size is null)
                return BadRequest($"Recipe with id: {key} does not exist on the server!");

            await cache.EvictByTagAsync("Recipes", cancellationToken);

            return Created(size);
        }

        [HttpPost("recipes({key})/addons")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Addon))]
        public async Task<IActionResult> AddAddonForRecipe(int key, [FromBody] CreateAddonDto addonDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Recipes action AddAddonForRecipe.");
            var addon = await _mediator
                .Send(new CreateRecipeAddonCommand
                {
                    Id = key,
                    AddonDto = addonDto
                });

            if (addon is null)
                return BadRequest($"Recipe with id: {key} does not exist on the server!");

            await cache.EvictByTagAsync("Recipes", cancellationToken);

            return Created(addon);
        }
        #endregion

        #region PUT
        [HttpPut("recipes({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateRecipe(int key, [FromForm] UpdateRecipeDto recipeDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Recipes action UpdateRecipe.");

            var currentRecipe = await _mediator
                .Send(new UpdateRecipeCommand
                {
                    Id = key,
                    RecipeDto = recipeDto
                });

            if (currentRecipe == null)
                return NotFound("recipe not found!");

            await cache.EvictByTagAsync("Recipes", cancellationToken);

            Log.Information($"Recipe with id: {key} has been updated.");
            return NoContent();
        }

        [HttpPut("recipes({key})/sizes({sizeId})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateSizeForRecipe(int key, int sizeId, [FromBody] UpdateSizeDto sizeDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Recipes action UpdateSizeForRecipe.");

            var currentSize = await _mediator
                .Send(new UpdateRecipeSizeCommand
                {
                    RecipeId = key,
                    SizeId = sizeId,
                    SizeDto = sizeDto,
                });

            if (currentSize == null)
                return NotFound("recipe or size not found!");

            await cache.EvictByTagAsync("Recipes", cancellationToken);

            Log.Information($"Recipe with id: {key} has been updated.");
            return NoContent();
        }

        [HttpPut("recipes({key})/addons({addonId})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAddonForRecipe(int key, int addonId, [FromBody] UpdateAddonDto addonDto, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Recipes action UpdateAddonForRecipe.");

            var currentAddon = await _mediator
                .Send(new UpdateRecipeAddonCommand
                {
                    RecipeId = key,
                    AddonId = addonId,
                    AddonDto = addonDto,
                });

            if (currentAddon == null)
                return NotFound("recipe or addon not found!");

            await cache.EvictByTagAsync("Recipes", cancellationToken);

            Log.Information($"Recipe with id: {key} has been updated.");
            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("recipes({key})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveRecipe(int key, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Recipes action RemoveRecipe.");

            var currentRecipe = await _mediator
                .Send(new DeleteRecipeCommand
                {
                    Id = key
                });

            if (currentRecipe is false)
                return NotFound("Recipe not found!");

            await cache.EvictByTagAsync("Recipes", cancellationToken);

            Log.Information($"Recipe with id: {key} has been marked as deleted.");
            return NoContent();
        }

        [HttpDelete("recipes({key})/sizes({sizeId})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveSizeForRecipe(int key, int sizeId, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Recipes action RemoveSizeForRecipe.");

            var currentSize = await _mediator
                .Send(new DeleteRecipeSizeCommand
                {
                    RecipeId = key,
                    SizeId = sizeId
                });

            if (currentSize is false)
                return NotFound("Size or Recipe not found!");

            await cache.EvictByTagAsync("Recipes", cancellationToken);

            Log.Information($"Size with id: {sizeId} has been marked as deleted.");
            return NoContent();
        }

        [HttpDelete("recipes({key})/addons({addonId})")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveAddonForRecipe(int key, int addonId, [FromServices] IOutputCacheStore cache, CancellationToken cancellationToken)
        {
            Log.Information("Starting controller Recipes action RemoveAddonForRecipe.");

            var currentSize = await _mediator
                .Send(new DeleteRecipeAddonCommand
                {
                    RecipeId = key,
                    AddonId = addonId
                });

            if (currentSize is false)
                return NotFound("Addon or Recipe not found!");

            await cache.EvictByTagAsync("Recipes", cancellationToken);

            Log.Information($"Addon with id: {addonId} has been marked as deleted.");
            return NoContent();
        }
        #endregion
    }
}
