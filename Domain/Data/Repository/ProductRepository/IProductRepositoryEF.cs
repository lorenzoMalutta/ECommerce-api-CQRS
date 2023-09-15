using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Model;

namespace agrolugue_api.Domain.Data.Repository.ProductRepository
{
    public interface IProductRepositoryEF : ICommands<Product>, IQueries<ReadProductRequest>
    {
    }
}
