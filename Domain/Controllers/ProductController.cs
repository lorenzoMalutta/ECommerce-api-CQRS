using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Responses.Products;
using CQRS101.Common;
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
        public async Task<IActionResult> Create(CancellationToken cancellation,
            [FromBody] CreateProductRequest command)
        {
            await _commandDispatcher.Dispatch<CreateProductRequest, CreateProductResponse>(command, cancellation);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellation,
            [FromQuery] ReadProductRequest command)
        {
            var response = await _queryDispatcher.Dispatch<ReadProductRequest, ReadProductResponse>(command, cancellation);

            return Ok(response);
        }
    }
}
