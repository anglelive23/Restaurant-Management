using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Features.Recipes.Commands.PatchRecipe
{
    public class RecipePatchDto
    {
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        [Required]
        //[Precision(18, 2)]
        public decimal InitialPrice { get; set; }
        [Range(0, 5)]
        public int? Rate { get; set; }
        public int? Discount { get; set; }
        public int? CategoryId { get; set; }
        public bool IsOffer { get; set; } = false;
        public int? CompanyId { get; set; }
    }
}
