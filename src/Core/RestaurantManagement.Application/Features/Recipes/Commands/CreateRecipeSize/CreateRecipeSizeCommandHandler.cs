namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipeSize
{
    public class CreateRecipeSizeCommandHandler : IRequestHandler<CreateRecipeSizeCommand, Size?>
    {
        #region Fields and Properties
        private readonly IRecipeRepository _repo;
        #endregion

        #region Constructors
        public CreateRecipeSizeCommandHandler(IRecipeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Size?> Handle(CreateRecipeSizeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CreateRecipeSizeCommandValidator();
                await validator.ValidateAndThrowAsync(request);

                var size = await _repo
                    .AddSizeForRecipeAsync(request.Id, request.SizeDto.Adapt<Size>());

                return size;
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
