using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Addons.Commands.DeleteAddon
{
    public class DeleteAddonCommandValidator : AbstractValidator<DeleteAddonCommand>
    {
        public DeleteAddonCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
