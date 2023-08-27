namespace RestaurantManagement.Application.Features.Contacts.Queries.GetContactDetailsQuery
{
    public class GetContactDetailsQueryValidator : AbstractValidator<GetContactDetailsQuery>
    {
        public GetContactDetailsQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
