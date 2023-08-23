using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Addons.Queries.GetAddonDetailsQuery
{
    public class GetAddonDetailsQueryValidator : AbstractValidator<GetAddonDetailsQuery>
    {
        public GetAddonDetailsQueryValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
