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

        public List<UserRequest> GetAllRequests()
        {
            var data=_LibraryManagementContext.UserRequests.ToList();
            return data;
        }

        public int MakeRequest(UserRequest urequest)
        {
             _LibraryManagementContext.UserRequests.AddAsync(urequest);
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
