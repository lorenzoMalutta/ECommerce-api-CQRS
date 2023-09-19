using System.ComponentModel.DataAnnotations;

namespace agrolugue_api.Domain.Commands.Requests.RentRequests
{
    public class CreateRentRequest
    {
        [Required]
        public string UserRentId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public DateTimeOffset RentDay { get; set; }

        [Required]
        public DateTimeOffset RentDeadLine { get; set; }
    }
}
