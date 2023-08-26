namespace RestaurantManagement.Application.Features.Categories.Queries.GetCategoryDetailsQuery
{
    public class GetCategoryDetailsQueryValidator : AbstractValidator<GetCategoryDetailsQuery>
    {
        public GetCategoryDetailsQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
