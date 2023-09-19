using agrolugue_api.Domain.Commands.Requests.RentRequests;
using agrolugue_api.Domain.Data.Context;
using agrolugue_api.Domain.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace agrolugue_api.Domain.Data.Repository.RentRepository
{
    public class RentRepositoryEF : IRentRepositoryEF
    {
        private readonly PersistContext _context;

        public RentRepositoryEF(PersistContext context)
        {
            _context = context;
        }

        public async Task<Rent> Create(Rent command)
        {
            await _context.AddAsync(command);

            return command;
        }

        public void Delete(Rent command)
        {
            throw new NotImplementedException();
        }

        public ReadRentRequest FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReadRentRequest> GetAll(int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public void Update(Rent command)
        {
            throw new NotImplementedException();
        }
    }
}
