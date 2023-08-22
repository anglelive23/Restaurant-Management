using RestaurantManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class Recipe : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
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
        public bool IsLiked { get; set; } = false;
        public Image? Image { get; set; }
        public int? ImageId { get; set; }
        public List<Size>? Sizes { get; set; }
        public List<Addons>? Addons { get; set; }
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public bool IsOffer { get; set; } = false;
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
    }
}
