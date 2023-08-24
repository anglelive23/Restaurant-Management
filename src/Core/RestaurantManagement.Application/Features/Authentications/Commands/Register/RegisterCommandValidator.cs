namespace RestaurantManagement.Application.Features.Authentications.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(20).WithMessage("{PropertyName} max length is 20!");

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(20).WithMessage("{PropertyName} max length is 20!");

            RuleFor(r => r.UserName)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(50).WithMessage("{PropertyName} max length is 50!");

            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(100).WithMessage("{PropertyName} max length is 100!")
                .EmailAddress().WithMessage("{PropertyName} must be email address!");


            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(50).WithMessage("{PropertyName} max length is 50!");

            RuleFor(r => r.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(11).WithMessage("{PropertyName} max length is 11!");
        }
    }
}
