namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        //private readonly IRecipeRepository _repo;

        public CreateRecipeCommandValidator(/*IRecipeRepository repo*/)
        {
            //_repo = repo ?? throw new ArgumentNullException(nameof(repo));
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(r => r.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");


            RuleFor(r => r.InitialPrice)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .PrecisionScale(18, 2, true).WithMessage("{PropertyName} precision is 18 and scale is 2.");

            RuleFor(r => r.Rate)
                .InclusiveBetween(0, 5).WithMessage("{PropertyName} must be between 0 and 5.");


            //RuleFor(e => e)
            //    .MustAsync(RecipeIsUnique).WithMessage("Recipe already exist on server!");
        }

        //private async Task<bool> RecipeIsUnique(CreateRecipeCommand r, CancellationToken cancellationToken)
        //{
        //    return await _repo.IsUniqueRecipe(r.Name);
        //}
    }
}
