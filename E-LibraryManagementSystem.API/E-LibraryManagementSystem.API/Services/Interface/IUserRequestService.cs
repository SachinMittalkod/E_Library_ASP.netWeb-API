
using E_LibraryManagementSystem.API.DataModel.Entities;
namespace E_LibraryManagementSystem.API.Services.Interface
{
    public interface IUserRequestService
    {

        public Task<IEnumerable<UserRequest>> GetAllRequests();
        public Task<int> MakeRequest(UserRequest urequest);
        public bool UpdateRequest(UserRequest urequest);
        public int GetNoOfRequests();
    }
}
