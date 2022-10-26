using E_LibraryManagementSystem.API.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.DataModels.Repository.Interface
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUserDetails();
        public Task<int> RegisterUser(User user);
        public Task<bool>  UpdateUser(User user);
        public Task<int> DeleteUser(int id);

        
    }
}
