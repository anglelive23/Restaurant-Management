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
        public int Id { get; set; }
        public decimal SalesPrice { get; set; }
        public int? DiscountApplied { get; set; }
        public Table? Table { get; set; }
        public int TableId { get; set; }
        public Location? Location { get; set; }
        public int LocationId { get; set; }
        public List<SalesLine>? SalesLines { get; set; }
        public Status? Status { get; set; }
        public int? StatusId { get; set; }
    }
}
