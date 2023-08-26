namespace RestaurantManagement.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(c => c.CategoryDto.LastModifiedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(c => c.CategoryDto.Image)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
