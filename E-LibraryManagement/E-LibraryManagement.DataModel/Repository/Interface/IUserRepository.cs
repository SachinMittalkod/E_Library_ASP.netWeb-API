using E_LibraryManagement.DataModel.DTO;
using E_LibraryManagement.DataModel.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagement.DataModel.Repository.Interface
{
    public interface IUserRepository
    {
        Task<int> AddUser(User user);
    }
}
