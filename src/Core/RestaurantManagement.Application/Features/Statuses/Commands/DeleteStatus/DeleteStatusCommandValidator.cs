namespace RestaurantManagement.Application.Features.Statuses.Commands.DeleteStatus
{
    public class DeleteStatusCommandValidator : AbstractValidator<DeleteStatusCommand>
    {
        public DeleteStatusCommandValidator()
        {
            RuleFor(l => l.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
