
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_Library.DataModels.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_LibraryManagementSystem.API.DataModel.Helper;

namespace E_Library.DataModels.Repository
{
    public class UserRequestRepository : IUserRequestRepository
    {
        int status=0;
        private readonly E_LibraryManagementContext _LibraryManagementContext;

        public UserRequestRepository(E_LibraryManagementContext e_LibraryManagementContext)
        {
            _LibraryManagementContext = e_LibraryManagementContext;
        }

    

     

        public async Task<IEnumerable<RequestedBook>> GetAllRequests()
        {
            var data=await  _LibraryManagementContext.RequestedBooks.ToListAsync();
            return data;
        }

        public  int GetNoOfRequests()
        {
            var data = _LibraryManagementContext.RequestedBooks.Select(x => x.RequestId).Count();
            if(data != null)
            {
                return data;
            }
            return 0;
            
        }

        public async Task<int> MakeRequest(RequestedBook urequest)
        {

            status = 1;
            var requestAdded = await _LibraryManagementContext.RequestedBooks.AddAsync(urequest);
            var userEmail = _LibraryManagementContext.Users.Where(u => u.UserId == urequest.UserId).Select(s => s.Email).FirstOrDefault();
            //var adminEmail = _LibraryManagementContext.Users.Where(a => a.RoleId == 1).Select(x => x.Email).FirstOrDefault();

            //string sender =Convert.ToString(userEmail);
            //string receiver = Convert.ToString(adminEmail);
            
            string receiver = Convert.ToString(userEmail);
            string sender = "sachinmittalkod@gmail.com";
            

            

            EmailService.smtpMailer(status,  sender, receiver, "");
            await _LibraryManagementContext.SaveChangesAsync();
            return 1;


        }

        public bool UpdateRequest(RequestedBook urequest)
        {
          
            _LibraryManagementContext.Update(urequest);
            _LibraryManagementContext.SaveChanges();
            return true;
        }

    }
}
