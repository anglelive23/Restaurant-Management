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
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Ocupation { get; set; }
        public string? PhoneNo1 { get; set; }
        public string? PhoneNo2 { get; set; }
        public string? PhoneNo3 { get; set; }
    }
}
