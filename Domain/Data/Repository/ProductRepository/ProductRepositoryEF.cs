using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Data.Context;
using agrolugue_api.Domain.Model;

namespace agrolugue_api.Domain.Data.Repository.ProductRepository
{
    public class ProductRepositoryEF : IProductRepositoryEF
    {
        private readonly PersistContext _context;

        public ProductRepositoryEF(PersistContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product command)
        {
            await _context.AddAsync(command);

            return command;
        }

        public void Delete(Product command)
        {
            _context.Remove(command);
        }

        public ReadProductRequest FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReadProductRequest> GetAll(int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public void Update(Product command)
        {
            _context.Update(command);
        }
    }
}
