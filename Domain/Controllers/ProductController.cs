using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Responses.Products;
using CQRS101.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace agrolugue_api.Domain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public ProductController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        [Authorize(Roles = "common-user")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest command, CancellationToken cancellation)
        {
            await _commandDispatcher.Dispatch<CreateProductRequest, CreateProductResponse>(command, cancellation);

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index([FromQuery] ReadProductRequest command, CancellationToken cancellation)
        {
            var response = await _queryDispatcher.Dispatch<ReadProductRequest, ReadProductResponse>(command, cancellation);

            return Ok(response);
        }
    }
}
