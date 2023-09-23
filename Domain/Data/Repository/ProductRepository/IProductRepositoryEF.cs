using agrolugue_api.Domain.Commands.Responses.Products;
using agrolugue_api.Domain.Model;

namespace agrolugue_api.Domain.Data.Repository.ProductRepository
{
    public interface IProductRepositoryEF : ICommands<Product>, IQueries<ReadProductResponse>
    {
    }
}
