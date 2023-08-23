namespace RestaurantManagement.Application.Features.Addons.Commands.UpdateAddon
{
    public class UpdateAddonCommandValidator : AbstractValidator<UpdateAddonCommand>
    {
        public UpdateAddonCommandValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(50);

            RuleFor(a => a.Price)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .PrecisionScale(18, 2, true);
        }
    }
}
