namespace RestaurantManagement.Application.Features.Addons.Queries.GetAddonDetailsQuery
{
    public class GetAddonDetailsQueryValidator : AbstractValidator<GetAddonDetailsQuery>
    {
        public GetAddonDetailsQueryValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
