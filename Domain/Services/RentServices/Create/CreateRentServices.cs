using agrolugue_api.Domain.Commands.Requests.RentRequests;
using agrolugue_api.Domain.Commands.Responses.RentResponses;
using agrolugue_api.Domain.Data.Repository.RentRepository;
using agrolugue_api.Domain.Models;

namespace agrolugue_api.Domain.Services.RentServices.Create
{
    public class CreateRentServices : ICreateRentServices
    {
        private readonly IRentRepositoryEF _repository;

        public CreateRentServices(IRentRepositoryEF repository)
        {
            _repository = repository;
        }

        public async Task<CreateRentResponse> Execute(CreateRentRequest command)
        {
            Rent rent = new()
            {
                ProductId = command.ProductId,
                UserRentId = command.UserRentId,
                RentDay = command.RentDay,
                RentDeadLine = command.RentDeadLine,
            };

            await _repository.Create(rent);

            var response = new CreateRentResponse
            {
                ErrorMessage = "Success"
            };

            return response;
        }

    }
}
