using agrolugue_api.Domain.Commands.Requests.RentRequests;
using agrolugue_api.Domain.Commands.Responses.RentResponses;

namespace agrolugue_api.Domain.Services.RentServices.Create
{
    public interface ICreateRentServices
    {
        Task<CreateRentResponse> Execute(CreateRentRequest command);
    }
}
