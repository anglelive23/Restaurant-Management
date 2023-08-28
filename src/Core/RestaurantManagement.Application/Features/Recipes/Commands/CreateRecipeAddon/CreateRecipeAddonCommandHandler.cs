namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipeAddon
{
    public class CreateRecipeAddonCommandHandler : IRequestHandler<CreateRecipeAddonCommand, Addon?>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public CreateRecipeAddonCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Addon?> Handle(CreateRecipeAddonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CreateRecipeAddonCommandValidator();
                await validator.ValidateAndThrowAsync(request);

                var addon = await _repo
                    .AddAddonForRecipeAsync(request.Id, request.AddonDto.Adapt<Addon>());

                return addon;
            }
            catch (Exception ex) when (ex is FluentValidation.ValidationException
                                    || ex is DataFailureException
                                    || ex is Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
