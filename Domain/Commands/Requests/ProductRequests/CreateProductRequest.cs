using System.ComponentModel.DataAnnotations;
using agrolugue_api.Domain.Model;

namespace agrolugue_api.Domain.Commands.Requests.Product
{
    public class CreateProductRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string OwnerId { get; set; }
    }
}
