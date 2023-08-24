namespace RestaurantManagement.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator()
        {
            RuleFor(a => a.Address.AddressLine1)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(120).WithMessage("{PropertyName} has max legth of 120!");

            RuleFor(a => a.Address.AddressLine2)
                .MaximumLength(120).WithMessage("{PropertyName} has max legth of 120!");

            RuleFor(a => a.Address.AddressLine3)
                .MaximumLength(120).WithMessage("{PropertyName} has max legth of 120!");
        }
    }
}
