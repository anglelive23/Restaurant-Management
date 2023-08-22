using RestaurantManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class Table : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TableNumber { get; set; }
    }
}
