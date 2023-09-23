using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Responses.Products;

namespace agrolugue_api.Domain.Services.ProductServices.ReadAll
{
    public interface IReadAllProductService
    {
        Task<ReadProductResponse> Execute(ReadProductRequest command);
    }
}
