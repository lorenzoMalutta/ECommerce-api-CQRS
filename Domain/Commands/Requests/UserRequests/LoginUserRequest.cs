using System.ComponentModel.DataAnnotations;

namespace agrolugue_api.Domain.Commands.Requests.UserRequest
{
    public class LoginUserRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
