using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Responses.Products;
using agrolugue_api.Domain.Services.ProductServices.ReadAll;
using CQRS101.Common;

namespace agrolugue_api.Domain.Handlers.ProductHandler
{
    public class ReadProductQueryHandler : IQueryHandler<ReadProductRequest, ReadProductResponse>
    {
        private readonly IReadAllProductService _service;

        public ReadProductQueryHandler(IReadAllProductService service)
        {
            _service = service;
        }

        public async Task<ReadProductResponse> Handle(ReadProductRequest query, CancellationToken cancellationToken)
        {
            var response = await _service.Execute(query);

            return response;
        }
    }
}
