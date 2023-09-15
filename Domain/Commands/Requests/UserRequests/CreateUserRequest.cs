using System.ComponentModel.DataAnnotations;

namespace agrolugue_api.Domain.Commands.Requests.UserRequest
{
    public class CreateUserRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^(?=.*[a-zA-Z0-9])", ErrorMessage = "A senha deve conter pelo menos um caractere alfanumérico.")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
