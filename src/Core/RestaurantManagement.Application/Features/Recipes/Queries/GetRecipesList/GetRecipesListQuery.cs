using MediatR;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Recipes.Queries.GetRecipesList
{
    public class GetRecipesListQuery : IRequest<IQueryable<Recipe>>
    {
    }
}
