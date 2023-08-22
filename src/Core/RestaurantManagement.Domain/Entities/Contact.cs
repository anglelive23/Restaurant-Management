using RestaurantManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class Contact : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [MaxLength(150)]
        public string? Ocupation { get; set; }
        [MaxLength(20)]
        public string? PhoneNo1 { get; set; }
        [MaxLength(20)]
        public string? PhoneNo2 { get; set; }
        [MaxLength(20)]
        public string? PhoneNo3 { get; set; }
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
    }
}
