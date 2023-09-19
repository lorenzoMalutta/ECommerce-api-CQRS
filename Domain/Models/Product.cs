using agrolugue_api.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agrolugue_api.Domain.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [ForeignKey("OwnerId")]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Rent> RentedProducts { get; set; } = new List<Rent>();
    }
}