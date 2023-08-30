namespace RestaurantManagement.Application.Features.Statuses.Queries.GetStatusDetails
{
    public class GetStatusDetailsQueryValidator : AbstractValidator<GetStatusDetailsQuery>
    {
        public GetStatusDetailsQueryValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
