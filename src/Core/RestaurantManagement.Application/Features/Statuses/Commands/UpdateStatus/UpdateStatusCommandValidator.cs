namespace RestaurantManagement.Application.Features.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusCommandValidator : AbstractValidator<UpdateStatusCommand>
    {
        public UpdateStatusCommandValidator()
        {
            RuleFor(l => l.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(l => l.StatusDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be null!")
                .MaximumLength(25).WithMessage("{PropertyName} has max length of 25!");

            RuleFor(l => l.StatusDto.LastModifiedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
