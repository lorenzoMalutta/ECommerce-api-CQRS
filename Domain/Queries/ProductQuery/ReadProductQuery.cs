using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Responses.Products;
using CQRS101.Common;

namespace agrolugue_api.Domain.Queries.ProductQuery
{
    public class ReadProductQuery : IQueryHandler<ReadProductRequest, ReadProductResponse>
    {

        public Task<ReadProductResponse> Handle(ReadProductRequest query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
