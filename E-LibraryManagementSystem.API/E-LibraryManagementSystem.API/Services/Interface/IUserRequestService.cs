
using E_LibraryManagementSystem.API.DataModel.Entities;
namespace E_LibraryManagementSystem.API.Services.Interface
{
    public interface IUserRequestService
    {

        public Task<IEnumerable<RequestedBook>> GetAllRequests();
        public Task<int> MakeRequest(RequestedBook urequest);
     
        public int GetNoOfRequests();
    }
}
