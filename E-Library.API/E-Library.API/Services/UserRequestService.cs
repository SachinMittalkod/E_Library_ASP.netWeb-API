using E_Library.API.Services.Interface;
using E_Library.DataModels.entities;
using E_Library.DataModels.Repository.Interface;

namespace E_Library.API.Services
{
    public class UserRequestService:IUserRequestService
    {
        private readonly IUserRequestRepository _userRequestRepository;

        public UserRequestService(IUserRequestRepository userRequestRepository)
        {
            _userRequestRepository = userRequestRepository;
        }

        public async Task<IEnumerable<UserRequest>> GetAllRequests()
        {
            return await _userRequestRepository.GetAllRequests();
        }

        public  int GetNoOfRequests()
        {
            return _userRequestRepository.GetNoOfRequests();
        }

        public Task<int> MakeRequest(UserRequest urequest)
        {
           return _userRequestRepository.MakeRequest(urequest);    
        }


        

        public bool UpdateRequest(UserRequest urequest)
        {
            return _userRequestRepository.UpdateRequest(urequest);
        }

        
    }
}
