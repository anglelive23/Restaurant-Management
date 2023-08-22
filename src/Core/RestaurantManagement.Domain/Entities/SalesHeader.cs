using RestaurantManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class SalesHeader : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        [Required]
        //[Precision(18, 2)]
        public decimal SalesPrice { get; set; }
        public int? DiscountApplied { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsDelivered { get; set; } = false;
        public bool IsCancelled { get; set; } = false;
        public Table? Table { get; set; }
        public int TableId { get; set; }
        public Company? Company { get; set; }
        public int CompanyId { get; set; }
        public Location? Location { get; set; }
        public int LocationId { get; set; }
        public List<SalesLine>? SalesLines { get; set; }
        public Status? Status { get; set; }
        public int? StatusId { get; set; }
    }
}
