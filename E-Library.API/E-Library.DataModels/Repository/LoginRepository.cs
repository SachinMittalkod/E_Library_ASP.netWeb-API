using E_Library.DataModels.DTO;
using E_Library.DataModels.entities;
using E_Library.DataModels.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.DataModels.Repository
{


    public class LoginRepository : ILoginRepository
    {
        private readonly E_LibraryManagementContext _e_LibraryManagementContext;
        

        public LoginRepository(E_LibraryManagementContext e_LibraryManagementContext)
        {
          
            _e_LibraryManagementContext = e_LibraryManagementContext;
        }

        public async Task<User> AuthenticateUser(LoginDTO loginDTO)
        {
            var userDetails = await _e_LibraryManagementContext.Users.FirstOrDefaultAsync(x => x.Name == loginDTO.Name
            && x.Password == loginDTO.Password);
            if(userDetails != null)
            {
                var user = new User()
                {
                    Name = userDetails.Name,
                    Password = userDetails.Password,
                };
                return user;    
            }
            else
            {
                return userDetails;
            }
        }
    }
}
