using agrolugue_api.Domain.Commands.Requests.RentRequests;
using agrolugue_api.Domain.Commands.Responses.RentResponses;
using agrolugue_api.Domain.Data;
using agrolugue_api.Domain.Services.RentServices.Create;
using CQRS101.Common;

namespace agrolugue_api.Domain.Handlers.RentHandler
{
    public class CreateRentHandler : ICommandHandler<CreateRentRequest, CreateRentResponse>
    {
        private readonly ICreateRentServices _services;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRentHandler(IUnitOfWork unitOfWork, ICreateRentServices services)
        {
            _unitOfWork = unitOfWork;
            _services = services;
        }

        public async Task<CreateRentResponse> Handle(CreateRentRequest command, CancellationToken cancellation)
        {
            try
            {
                await _services.Execute(command);

                _unitOfWork.Commit();

               var response = new CreateRentResponse {
                   ErrorMessage = "Success"
               };

                return response;
            }
            catch (Exception ex) 
            {
                _unitOfWork.Rollback();
                throw new Exception("Unnexpected error - 500: " + ex);
            }

        }
    }
}
