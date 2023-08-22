using RestaurantManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class SalesLine : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        [Required]
        //[Precision(18, 2)]
        public decimal SalesPrice { get; set; }
        public int? DiscountApplied { get; set; }
        public int Quantity { get; set; } = 1;
        public Recipe? Recipe { get; set; }
        public int RecipeId { get; set; }
        [Required]
        public string Size { get; set; } = string.Empty;
        [Required]
        public string Addons { get; set; } = string.Empty;
        public SalesHeader? SalesHeader { get; set; }
        public int SalesHeaderId { get; set; }
        [MaxLength(100)]
        public string? Note { get; set; }
    }
}
