using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Responses.Products;
using agrolugue_api.Domain.Data;
using agrolugue_api.Domain.Services.ProductServices.Create;
using CQRS101.Common;

namespace agrolugue_api.Domain.Handlers.ProductHandler
{
    public class CreateProductHandler : ICommandHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly ICreateProductServices _services;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductHandler(ICreateProductServices services, IUnitOfWork unitOfWork)
        {
            _services = services;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest command, CancellationToken cancellation)
        {
            try
            {
                var res = await _services.Execute(command);

                _unitOfWork.Commit();

                var response = new CreateProductResponse{
                    OwnerId = res.OwnerId,
                    Id = res.Id,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(" Unexpected Error: " + ex);
            }
        }
    }
}
