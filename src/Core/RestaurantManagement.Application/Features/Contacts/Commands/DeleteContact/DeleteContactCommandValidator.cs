namespace RestaurantManagement.Application.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
