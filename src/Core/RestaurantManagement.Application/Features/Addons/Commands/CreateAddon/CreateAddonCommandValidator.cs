﻿namespace RestaurantManagement.Application.Features.Addons.Commands.CreateAddon
{
    public class CreateAddonCommandValidator : AbstractValidator<CreateAddonCommand>
    {
        public CreateAddonCommandValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(50);

            RuleFor(a => a.Price)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .PrecisionScale(18, 2, true);
        }
    }
}
