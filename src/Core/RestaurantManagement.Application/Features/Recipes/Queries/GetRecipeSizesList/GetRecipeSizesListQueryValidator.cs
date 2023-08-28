namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipeSizesList
{
    public class GetRecipeSizesListQueryValidator : AbstractValidator<GetRecipeSizesListQuery>
    {
        public GetRecipeSizesListQueryValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
