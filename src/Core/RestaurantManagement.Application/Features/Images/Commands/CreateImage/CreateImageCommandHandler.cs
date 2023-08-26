namespace RestaurantManagement.Application.Features.Images.Commands.CreateImage
{
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, Image>
    {
        #region Fields and Properties
        private readonly IImageRepository _repo;
        #endregion

        #region Constructors
        public CreateImageCommandHandler(IImageRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        #endregion

        #region Interface Implementation
        public async Task<Image> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var validator = new CreateImageCommandValidator();
                await validator.ValidateAndThrowAsync(request, cancellationToken);

                var checkAdd = await _repo.AddImageAsync(request.Adapt<Image>());
                return checkAdd;
            }
            catch (Exception ex) when (ex is FluentValidation.ValidationException
                                    || ex is DataFailureException)
            {
                throw;
            }
        }
        #endregion
    }
}
