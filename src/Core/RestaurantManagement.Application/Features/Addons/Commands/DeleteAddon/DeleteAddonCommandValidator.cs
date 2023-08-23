namespace RestaurantManagement.Application.Features.Addons.Commands.DeleteAddon
{
    public class DeleteAddonCommandValidator : AbstractValidator<DeleteAddonCommand>
    {
        public DeleteAddonCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
