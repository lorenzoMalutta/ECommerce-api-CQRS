using agrolugue_api.Domain.Model;
using agrolugue_api.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace agrolugue_api.Domain.Commands.Responses.Products
{
    public class ReadProductResponse
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

        public string OwnerId { get; set; }
    }
}
