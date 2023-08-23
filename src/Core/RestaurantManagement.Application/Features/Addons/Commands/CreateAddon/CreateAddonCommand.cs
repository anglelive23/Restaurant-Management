using MediatR;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Addons.Commands.CreateAddon
{
    public class CreateAddonCommand : IRequest<Addon?>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? RecipeId { get; set; }
        public string? CreatedBy { get; set; }
    }
}
