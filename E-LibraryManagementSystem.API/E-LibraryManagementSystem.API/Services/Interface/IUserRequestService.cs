
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.ServiceModel.DTO.Response;

namespace E_LibraryManagementSystem.API.Services.Interface
{
    public interface IUserRequestService
    {

        public Task<IEnumerable<RespRequestedBookDTO>> GetAllRequests();
        public Task<int> MakeRequest(RequestedBook urequest);
     
        public int GetNoOfRequests();
    }
}
