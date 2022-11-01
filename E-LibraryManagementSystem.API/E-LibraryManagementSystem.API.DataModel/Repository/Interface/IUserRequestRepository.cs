
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.ServiceModel.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.DataModels.Repository.Interface
{
    public interface IUserRequestRepository
    {
        public Task<int> MakeRequest(RequestedBook urequest);
 

        public Task<IEnumerable<RespRequestedBookDTO>> GetAllRequests();

        public Task<int> DeleteRequest(int id);
        public int GetNoOfRequests();
    }
}
