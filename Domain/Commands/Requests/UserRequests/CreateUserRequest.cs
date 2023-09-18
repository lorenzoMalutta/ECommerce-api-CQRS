using System.ComponentModel.DataAnnotations;

namespace agrolugue_api.Domain.Commands.Requests.UserRequest
{
    public class CreateUserRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^(?=.*[a-zA-Z0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "The password must have at least one special character and alphanumeric characters")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
