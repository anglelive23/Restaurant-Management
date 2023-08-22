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
        public int Id { get; set; }
        public decimal SalesPrice { get; set; }
        public int? DiscountApplied { get; set; }
        public int Quantity { get; set; } = 1;
        public Recipe? Recipe { get; set; }
        public int RecipeId { get; set; }
        public string Size { get; set; }
        public string Addons { get; set; }
        public SalesHeader? SalesHeader { get; set; }
        public int SalesHeaderId { get; set; }
        public string? Note { get; set; }
    }
}
