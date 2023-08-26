namespace RestaurantManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(256).WithMessage("{PropertyName} max length is 256");

            RuleFor(i => i.Image)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(i => i.CreatedBy)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
