using agrolugue_api.Domain.Commands.Requests.UserRequest;
using agrolugue_api.Domain.Commands.Responses.UserResponse;
using agrolugue_api.Domain.Model;
using agrolugue_api.Domain.Services.TokenServices;
using CQRS101.Common;
using Microsoft.AspNetCore.Identity;

namespace agrolugue_api.Domain.Handlers.UserHandler
{
    public class LoginUserHandler : ICommandHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenServices _services;
        private readonly UserManager<User> _userManager;
        public LoginUserHandler(SignInManager<User> signInManager, ITokenServices services, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _services = services;
            _userManager = userManager;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest command, CancellationToken cancellation)
        {
            var result = await _signInManager.PasswordSignInAsync(command.UserName, command.Password, false, false);

            var user = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == command.UserName.ToUpper());

            var roles = await _userManager.GetRolesAsync(user);

            var token = _services.GenerateToken(user, roles);

            var response = new LoginUserResponse
            {
                Token = token
            };

            return response;
        }
    }
}
