using MediatR;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Recipes
{
    public class GetRecipeDetailsQuery : IRequest<Recipe>
    {
        public int Id { get; set; }
    }
}
