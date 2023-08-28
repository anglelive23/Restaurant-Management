namespace RestaurantManagement.Application.Features.Recipes.Commands.UpdateRecipeSize
{
    public class UpdateRecipeSizeCommandValidator : AbstractValidator<UpdateRecipeSizeCommand>
    {
        public UpdateRecipeSizeCommandValidator()
        {
            RuleFor(r => r.RecipeId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(r => r.SizeId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(r => r.SizeDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(50).WithMessage("{PropertyName} has max length of 50");


            RuleFor(r => r.SizeDto.Price)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .PrecisionScale(18, 2, true).WithMessage("{PropertyName} precision is (18, 2)");

            RuleFor(r => r.SizeDto.LastModifiedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
