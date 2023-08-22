using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using RestaurantManagement.Domain.Common;

namespace RestaurantManagement.Domain.Entities
{
    public class Company : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(255)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Code { get; set; } = Guid.NewGuid();
        public Address? Address { get; set; }
        public int? AddressId { get; set; }
        public Image? Image { get; set; }
        public int ImageId { get; set; }
        public List<Location>? Locations { get; set; }
        public List<Contact>? Contacts { get; set; }
    }
}
