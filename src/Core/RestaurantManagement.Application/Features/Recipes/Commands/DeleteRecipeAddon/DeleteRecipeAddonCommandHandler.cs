namespace RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipeAddon
{
    public class DeleteRecipeAddonCommandHandler : IRequestHandler<DeleteRecipeAddonCommand, bool>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public DeleteRecipeAddonCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(DeleteRecipeAddonCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteRecipeAddonCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkDelete = await _repo
                .RemoveAddonForRecipeAsync(request.RecipeId, request.AddonId);
            return checkDelete;
        }
        #endregion
    }
}
