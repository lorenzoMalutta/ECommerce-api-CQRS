using agrolugue_api.Domain.Commands.Requests.UserRequest;
using agrolugue_api.Domain.Commands.Responses.UserResponse;
using agrolugue_api.Domain.Exceptions.PasswordValidation;
using agrolugue_api.Domain.Model;
using CQRS101.Common;
using Microsoft.AspNetCore.Identity;

namespace agrolugue_api.Domain.Handlers.UserHandler
{
    public class CreateUserHandler : ICommandHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly UserManager<User> _userManager;
        public CreateUserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest command, CancellationToken cancellation)
        {
            try
            {
                PasswordValidation validation = new();

                if(!validation.IsValid(command.Password)) 
                    throw new PasswordValidationException("The password must have alphnumerics");

                User user = new()
                {
                    UserName = command.UserName,
                    Email = command.Email,
                };
    
                var result = await _userManager.CreateAsync(user, command.Password);

                return null;

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
