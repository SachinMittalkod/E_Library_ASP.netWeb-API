using E_LibraryManagement.DataModel.DTO;
using E_LibraryManagement.DataModel.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LibraryManagement.Services.Interface
{
    public interface IAddUserService
    {


        Task<int> AddUser(User user);
    }
}
