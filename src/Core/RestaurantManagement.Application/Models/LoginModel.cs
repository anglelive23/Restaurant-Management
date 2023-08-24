using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Models
{
    public class LoginModel
    {
        [Required, MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
    }
}
