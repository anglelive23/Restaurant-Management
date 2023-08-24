namespace RestaurantManagement.Application.Features.Files.Command.SaveImageCommand
{
    public class SaveImageCommandHandler : IRequestHandler<SaveImageCommand, bool>
    {
        #region Fields and Properties
        private readonly IFileService _fileService;
        #endregion

        #region Constructors
        public SaveImageCommandHandler(IFileService fileService)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }
        #endregion

        #region Interface Implementation
        public async Task<bool> Handle(SaveImageCommand request, CancellationToken cancellationToken)
        {
            var validator = new SaveImageCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            try
            {
                var checkSave = _fileService.SaveImageToServer(request.File, request.SubFolder);
                return checkSave;
            }
            catch (Exception ex) when (ex is IOException
                                    || ex is Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
