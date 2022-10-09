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

        public List<UserRequest> GetAllRequests()
        {
            return _userRequestRepository.GetAllRequests();
        }

        public int MakeRequest(UserRequest urequest)
        {
           return _userRequestRepository.MakeRequest(urequest);
          
            
        }

        public bool UpdateRequest(UserRequest urequest)
        {
            return _userRequestRepository.UpdateRequest(urequest);
        }
    }
}
