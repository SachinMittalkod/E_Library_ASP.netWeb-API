using E_Library.DataModels.entities;

namespace E_Library.API.Services.Interface
{
    public interface IUserRequestService
    {
    
        public List<UserRequest> GetAllRequests();
        public int MakeRequest(UserRequest urequest);
        public bool UpdateRequest(UserRequest urequest);
    }
}
