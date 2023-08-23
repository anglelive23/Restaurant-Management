using MediatR;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Addons.Commands.UpdateAddon
{
    public class UpdateAddonCommand : IRequest<Addon?>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? RecipeId { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
