
using E_LibraryManagementSystem.API.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.DataModels.Repository.Interface
{
    public interface ILoginRepository
    {
       
        Task<User> LoginUser(User login);
        //bool CheckUserAvailabity(string userName);

        //bool isUserExists(int userId);
    }
}
