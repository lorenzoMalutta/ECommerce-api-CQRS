using agrolugue_api.Domain.Commands.Requests.UserRequest;
using agrolugue_api.Domain.Commands.Responses.UserResponse;
using agrolugue_api.Domain.Exceptions.PasswordValidation;
using agrolugue_api.Domain.Model;
using agrolugue_api.Domain.Services.UserServices.Create;
using CQRS101.Common;
using Microsoft.AspNetCore.Identity;

namespace agrolugue_api.Domain.Handlers.UserHandler
{
    public class CreateUserHandler : ICommandHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly ICreateUserService _service;

        public CreateUserHandler(ICreateUserService service)
        {
            _service = service;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest command, CancellationToken cancellation)
        {
            await _service.Execute(command);

            return new CreateUserResponse
            {
                ErrorMessage = "Success"
            };
        }
    }
}
