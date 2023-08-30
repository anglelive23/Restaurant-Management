namespace RestaurantManagement.Application.Features.Locations.Queries.GetLocationDetails
{
    public class GetLocationDetailsQueryValidator : AbstractValidator<GetLocationDetailsQuery>
    {
        public GetLocationDetailsQueryValidator()
        {
            RuleFor(l => l.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
