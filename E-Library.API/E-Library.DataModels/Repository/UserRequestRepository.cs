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
    public class UserRequestRepository : IUserRequestRepository
    {
        private readonly E_LibraryManagementContext _LibraryManagementContext;

        public UserRequestRepository(E_LibraryManagementContext e_LibraryManagementContext)
        {
            _LibraryManagementContext = e_LibraryManagementContext;
        }

        public async Task<IEnumerable<UserRequest>> GetAllRequests()
        {
            var data=await  _LibraryManagementContext.UserRequests.ToListAsync();
            return data;
        }

        public async Task<int> MakeRequest(UserRequest urequest)
        {
             await _LibraryManagementContext.UserRequests.AddAsync(urequest);
             _LibraryManagementContext.SaveChanges();    
            return 1;
        }

        public bool UpdateRequest(UserRequest urequest)
        {
          
            _LibraryManagementContext.Update(urequest);
            _LibraryManagementContext.SaveChanges();
            return true;
        }

    }
}
