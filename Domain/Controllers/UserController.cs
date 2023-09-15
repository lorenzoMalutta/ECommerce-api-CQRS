using agrolugue_api.Domain.Commands.Requests.UserRequest;
using agrolugue_api.Domain.Commands.Responses.UserResponse;
using agrolugue_api.Domain.Handlers.UserHandler;
using CQRS101.Common;
using Microsoft.AspNetCore.Mvc;

namespace agrolugue_api.Domain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public UserController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CancellationToken cancellation,
           [FromBody] CreateUserRequest command)
        {
            await _commandDispatcher.Dispatch<CreateUserRequest, CreateUserResponse>(command, cancellation);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(CancellationToken cancellation, [FromBody] 
        LoginUserRequest command) 
        {
            var token = await _commandDispatcher.Dispatch<LoginUserRequest, LoginUserResponse>(command, cancellation);

            return Ok(token);
        }
    }
}
