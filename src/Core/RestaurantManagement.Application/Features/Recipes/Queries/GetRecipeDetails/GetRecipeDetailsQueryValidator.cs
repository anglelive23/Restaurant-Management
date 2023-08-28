namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeDetails
{
    public class GetRecipeDetailsQueryValidator : AbstractValidator<GetRecipeDetailsQuery>
    {
        public GetRecipeDetailsQueryValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
