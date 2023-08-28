﻿namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Recipe?>
    {
        #region Fields and Properties
        private readonly IRecipeService _recipeService;
        #endregion

        #region Constructors
        public CreateRecipeCommandHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));
        }
        #endregion

        #region Interface Implementation
        public async Task<Recipe?> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CreateRecipeCommandValidator();
                await validator.ValidateAndThrowAsync(request);

                var recipe = await _recipeService
                    .AddRecipeWithImageAsync(request.RecipeDto);

                return recipe;
            }
            catch (Exception ex) when (ex is FluentValidation.ValidationException
                                    || ex is DataFailureException
                                    || ex is ApplicationException
                                    || ex is Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
