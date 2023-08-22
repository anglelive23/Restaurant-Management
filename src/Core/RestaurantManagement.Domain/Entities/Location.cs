using RestaurantManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class Location : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(250)]
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? County { get; set; }
        [MaxLength(50)]
        public string? Town { get; set; }
        [Required]
        public int SeatQty { get; set; }
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
    }
}
