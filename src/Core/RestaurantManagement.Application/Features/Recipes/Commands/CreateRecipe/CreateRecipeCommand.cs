using MediatR;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommand : IRequest<Recipe?>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal InitialPrice { get; set; }
        public int? Rate { get; set; }
        public int? Discount { get; set; }
        public Image? Image { get; set; }
        public int? ImageId { get; set; }
        public List<Size>? Sizes { get; set; }
        public List<Addon>? Addons { get; set; }
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public bool IsOffer { get; set; } = false;
    }
}
