using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Responses.Products;
using agrolugue_api.Domain.Data.Repository.ProductRepository;
using agrolugue_api.Domain.Model;

namespace agrolugue_api.Domain.Services.ProductServices.Create
{
    public class CreateProductServices : ICreateProductServices
    {
        private readonly IProductRepositoryEF _repository;

        public CreateProductServices(IProductRepositoryEF repository)
        {
            _repository = repository;
        }

        public CreateProductResponse Execute(CreateProductRequest obj)
        {
            Product product = new()
            {
                DateTime = obj.DateTime,
                Name = obj.Name,
                OwnerId = obj.OwnerId,
                Price = obj.Price,
                Description = obj.Description,
            };

            _repository.Create(product);

            var response = new CreateProductResponse
            {
                Id = product.Id,
                OwnerId = product.OwnerId
            };

            return response;
        }
    }
}
