using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Responses.Products;

namespace agrolugue_api.Domain.Services.ProductServices.Create
{
    public interface ICreateProductServices
    {
        public Task<CreateProductResponse> Execute(CreateProductRequest obj);
    }
}
