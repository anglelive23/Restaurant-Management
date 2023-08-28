namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeAddonsList
{
    public class GetRecipeAddonsListQueryValidator : AbstractValidator<GetRecipeAddonsListQuery>
    {
        public GetRecipeAddonsListQueryValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
