using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Responses.Products;
using agrolugue_api.Domain.Data.Context;
using agrolugue_api.Domain.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace agrolugue_api.Domain.Data.Repository.ProductRepository
{
    public class ProductRepositoryEF : IProductRepositoryEF
    {
        private readonly PersistContext _context;
        private readonly ReadContext _readContext;

        public ProductRepositoryEF(PersistContext context, ReadContext readContext)
        {
            _context = context;
            _readContext = readContext;
        }

        public Product Create(Product command)
        {
            _context.AddAsync(command);

            return command;
        }

        public void Delete(Product command)
        {
            _context.Remove(command);
        }

        public async Task<ReadProductResponse> FindById(string id)
        {
            var product = await _readContext.Products.FindAsync(id);

            return (ReadProductResponse)product;
        }

        public async Task<IEnumerable<ReadProductResponse>> GetAll(int skip = 0, int take = 10)
        {
            var product = await _readContext.Products.FindAsync(products => true);
           
            return (IEnumerable<ReadProductResponse>)product.ToList();
        }

        public void Update(Product command)
        {
            _context.Update(command);
        }
    }
}
