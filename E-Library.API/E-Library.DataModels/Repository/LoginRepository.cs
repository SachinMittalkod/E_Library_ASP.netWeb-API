using E_Library.DataModels.DTO;
using E_Library.DataModels.entities;
using E_Library.DataModels.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace E_Library.DataModels.Repository
{


    public class LoginRepository : ILoginRepository
    {
        private readonly E_LibraryManagementContext _e_LibraryManagementContext;
     

        public LoginRepository(E_LibraryManagementContext e_LibraryManagementContext
          )
        {
          
            _e_LibraryManagementContext = e_LibraryManagementContext;
            
        }

        public async Task<User> LoginUser(User login)
        {
            User user = await _e_LibraryManagementContext.Users.FirstOrDefaultAsync(x => x.Name == login.Name && x.Password == login.Password);

            return user;

        }
    }
}
