namespace RestaurantManagement.Application.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(c => c.ContactDto.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(50).WithMessage("{PropertyName} max length is 50!");

            RuleFor(c => c.ContactDto.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(50).WithMessage("{PropertyName} max length is 50!");

            RuleFor(c => c.ContactDto.Ocupation)
                .MaximumLength(150).WithMessage("{PropertyName} max length is 150!");

            RuleFor(c => c.ContactDto.PhoneNo1)
                .MaximumLength(20).WithMessage("    {PropertyName} max length is 20!");

            RuleFor(c => c.ContactDto.PhoneNo2)
                .MaximumLength(20).WithMessage("{PropertyName} max length is 20!");

            RuleFor(c => c.ContactDto.PhoneNo3)
                .MaximumLength(20).WithMessage("{PropertyName} max length is 20!");

            RuleFor(c => c.ContactDto.LastModifiedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
