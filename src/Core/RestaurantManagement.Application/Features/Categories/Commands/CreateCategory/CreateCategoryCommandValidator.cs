namespace RestaurantManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(256).WithMessage("{PropertyName} max length is 256");
        }
    }
}
