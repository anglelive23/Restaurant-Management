namespace RestaurantManagement.Application.Features.Files.Command.SaveImageCommand
{
    public class SaveImageCommandValidator : AbstractValidator<SaveImageCommand>
    {
        public SaveImageCommandValidator()
        {
            RuleFor(i => i.SubFolder)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(i => i.File)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
