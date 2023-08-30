namespace RestaurantManagement.Application.Features.Statuses.Commands.CreateStatus
{
    public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
    {
        public CreateStatusCommandValidator()
        {
            RuleFor(l => l.StatusDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be null!")
                .MaximumLength(25).WithMessage("{PropertyName} has max length of 25!");

            RuleFor(l => l.StatusDto.CreatedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
