using RestaurantManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class Image : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Path { get; set; }
        [Required, MaxLength(25)]
        public string Description { get; set; } = null!;
    }
}
