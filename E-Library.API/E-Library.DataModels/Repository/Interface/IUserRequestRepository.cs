
using E_Library.DataModels.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.DataModels.Repository.Interface
{
    public interface IUserRequestRepository
    {
        public Task<int> MakeRequest(UserRequest urequest);
        public bool UpdateRequest(UserRequest urequest);

        public Task<IEnumerable<UserRequest>> GetAllRequests();
        public int GetNoOfRequests();
    }
}
