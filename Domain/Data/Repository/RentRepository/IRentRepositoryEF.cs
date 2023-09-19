using agrolugue_api.Domain.Commands.Requests.Product;
using agrolugue_api.Domain.Commands.Requests.RentRequests;
using agrolugue_api.Domain.Models;

namespace agrolugue_api.Domain.Data.Repository.RentRepository
{
    public interface IRentRepositoryEF : ICommands<Rent>, IQueries<ReadRentRequest>
    {
    }
}
