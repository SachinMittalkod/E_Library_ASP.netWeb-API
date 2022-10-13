using E_Library.DataModels.entities;

namespace E_Library.API.Services.Interface
{
    public interface IUserRequestService
    {

        public Task<IEnumerable<UserRequest>> GetAllRequests();
        public Task<int> MakeRequest(UserRequest urequest);
        public bool UpdateRequest(UserRequest urequest);
        public int GetNoOfRequests();
    }
}
