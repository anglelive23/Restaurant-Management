using RestaurantManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class Address : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string AddressLine1 { get; set; } = string.Empty;
        [MaxLength(120)]
        public string? AddressLine2 { get; set; } = string.Empty;
        [MaxLength(120)]
        public string? AddressLine3 { get; set; } = string.Empty;
    }
}
