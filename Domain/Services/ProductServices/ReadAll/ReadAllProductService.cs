using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Responses.Products;
using agrolugue_api.Domain.Data.Repository.ProductRepository;

namespace agrolugue_api.Domain.Services.ProductServices.ReadAll
{
    public class ReadAllProductService : IReadAllProductService
    {
        private readonly IProductRepositoryEF _repository;

        public ReadAllProductService(IProductRepositoryEF repository)
        {
            _repository = repository;
        }

        public async Task<ReadProductResponse> Execute(ReadProductRequest command)
        {
            var response = await _repository.GetAll(command.Skip, command.Take);

            return (ReadProductResponse)response;
        }
    }
}
