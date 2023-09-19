using agrolugue_api.Domain.Commands.Requests.RentRequests;
using agrolugue_api.Domain.Commands.Responses.RentResponses;
using CQRS101.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace agrolugue_api.Domain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public RentController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        [Authorize(Roles = "common-user")]
        public async Task<IActionResult> Create([FromBody] CreateRentRequest command, CancellationToken cancellationToken) 
        {
            await _commandDispatcher.Dispatch<CreateRentRequest, CreateRentResponse>(command, cancellationToken);

            return Ok();
        }
    }
}
