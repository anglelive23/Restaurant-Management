namespace RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipeAddon
{
    public class UpdateRecipeAddonCommandHandler : IRequestHandler<UpdateRecipeAddonCommand, Addon?>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public UpdateRecipeAddonCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Addon?> Handle(UpdateRecipeAddonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new UpdateRecipeAddonCommandValidator();
                await validator.ValidateAndThrowAsync(request, cancellationToken);

                var checkUpdate = await _repo
                    .UpdateAddonForRecipeAsync(request.RecipeId, request.AddonId, request.AddonDto.Adapt<Addon>());
                return checkUpdate;
            }
            catch (Exception ex) when (ex is DataFailureException
                                    || ex is FluentValidation.ValidationException
                                    || ex is Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
