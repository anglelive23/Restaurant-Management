namespace RestaurantManagement.Application.Features.Addresses.Queries.GetAddressDetailsQuery
{
    public class GetAddressDetailsQueryValidator : AbstractValidator<GetAddressDetailsQuery>
    {
        public GetAddressDetailsQueryValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
