using agrolugue_api.Domain.Commands.Requests.UserRequest;
using agrolugue_api.Domain.Commands.Responses.UserResponse;
using agrolugue_api.Domain.Exceptions.PasswordValidation;
using agrolugue_api.Domain.Model;
using agrolugue_api.Domain.Services.UserServices.Create;
using Microsoft.AspNetCore.Identity;

namespace agrolugue_api.Domain.Services.UserServices
{
    public class CreateUserService : ICreateUserService
    {
        private readonly UserManager<User> _userManager;
        public CreateUserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<CreateUserResponse> Execute(CreateUserRequest command)
        {
            try
            {
                PasswordValidation validation = new();

                if (!validation.IsValid(command.Password))
                    throw new PasswordValidationException("The password must have alphnumerics");

                User user = new()
                {
                    UserName = command.UserName,
                    Email = command.Email,
                    DateTime = DateTime.UtcNow,
                };
                

                var result = await _userManager.CreateAsync(user, command.Password);

                await _userManager.AddToRoleAsync(user, "common-user");

                if (result.Succeeded)
                {
                    return new CreateUserResponse
                    {
                        ErrorMessage = "Sucess"
                    };
                } else
                {
                    throw new Exception("Unexpected exception - 500");
                }
            }
            catch (PasswordValidationException ex)
            {
                return new CreateUserResponse { ErrorMessage = ex.Message };
            }
            catch (Exception ex)
            {
                return new CreateUserResponse { ErrorMessage = ex.Message };
            }
        }
    }
}
