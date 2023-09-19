using agrolugue_api.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agrolugue_api.Domain.Models
{
    public class Rent
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTimeOffset RentDay { get; set; }

        [Required]
        public DateTimeOffset RentDeadLine { get; set; }

        [Required]
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        [ForeignKey("UserRentId")]
        public string UserRentId { get; set; }

        public virtual User UserRent { get; set; }

    }
}
