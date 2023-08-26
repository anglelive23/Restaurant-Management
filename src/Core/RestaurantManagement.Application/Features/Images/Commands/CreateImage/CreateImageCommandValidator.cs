namespace RestaurantManagement.Application.Features.Images.Commands.CreateImage
{
    public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
    {
        public CreateImageCommandValidator()
        {
            RuleFor(i => i.Path)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(i => i.CreatedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
