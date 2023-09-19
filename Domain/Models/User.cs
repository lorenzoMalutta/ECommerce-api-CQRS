using agrolugue_api.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agrolugue_api.Domain.Model
{
    public class User : IdentityUser
    {
        [Required]
        public DateTime DateTime { get; set; }
        public User() : base() { }
        public virtual ICollection<Product> OwnedProducts { get; set; } = new List<Product>();
        public virtual ICollection<Rent> RentedProducts { get; set; } = new List<Rent>();
    }
}
