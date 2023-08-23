namespace RestaurantManagement.Application.Features.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, bool>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public DeleteRecipeCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var checkDelete = await _repo.RemoveRecipeAsync(request.Id);
            return checkDelete;
        }
        #endregion
    }
}
