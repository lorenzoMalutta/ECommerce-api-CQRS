using agrolugue_api.Domain.Commands.Requests.UserRequest;
using agrolugue_api.Domain.Commands.Responses.UserResponse;

namespace agrolugue_api.Domain.Services.UserServices.Create
{
    public interface ICreateUserService
    {
        Task<CreateUserResponse> Execute(CreateUserRequest command);
    }
}
