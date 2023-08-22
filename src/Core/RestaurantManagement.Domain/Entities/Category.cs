using RestaurantManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RestaurantManagement.Domain.Entities
{
    public class Category : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public Image? Image { get; set; }
        public int? ImageId { get; set; }
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
        public List<Recipe>? Recipes { get; set; }
    }
}
