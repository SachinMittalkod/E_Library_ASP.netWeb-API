using E_Library.DataModels.Repository.Interface;
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.API.Services.Interface;
using E_LibraryManagementSystem.ServiceModel.DTO.Response;

namespace E_Library.API.Services
{
    public class UserRequestService:IUserRequestService
    {
        private readonly IUserRequestRepository _userRequestRepository;

        public UserRequestService(IUserRequestRepository userRequestRepository)
        {
            _userRequestRepository = userRequestRepository;
        }

        public async Task<IEnumerable<RespRequestedBookDTO>> GetAllRequests()
        {
            return await _userRequestRepository.GetAllRequests();
        }

        public  int GetNoOfRequests()
        {
            return _userRequestRepository.GetNoOfRequests();
        }

        public Task<int> MakeRequest(RequestedBook urequest)
        {
           return _userRequestRepository.MakeRequest(urequest);    
        }

        
    }
}
