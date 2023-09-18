using agrolugue_api.Domain.Commands.Requests.UserRequest;
using agrolugue_api.Domain.Commands.Responses.UserResponse;
using agrolugue_api.Domain.Handlers.UserHandler;
using CQRS101.Common;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest command, CancellationToken cancellation)
        {
            await _commandDispatcher.Dispatch<CreateUserRequest, CreateUserResponse>(command, cancellation);

            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest command, CancellationToken cancellation) 
        {
            var token = await _commandDispatcher.Dispatch<LoginUserRequest, LoginUserResponse>(command, cancellation);

            return Ok(token);
        }
    }
}
