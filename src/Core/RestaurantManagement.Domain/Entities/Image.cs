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
        public int Id { get; set; }
        public string? Path { get; set; }
        public string Description { get; set; }
    }
}
