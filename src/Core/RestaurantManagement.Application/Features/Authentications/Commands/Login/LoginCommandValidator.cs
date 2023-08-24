namespace RestaurantManagement.Application.Features.Authentications.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(100).WithMessage("{PropertyName} max length is 100!")
                .EmailAddress().WithMessage("{PropertyName} must be email address!");

            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(50).WithMessage("{PropertyName} max length is 50!");
        }
    }
}
