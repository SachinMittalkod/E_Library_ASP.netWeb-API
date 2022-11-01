
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_Library.DataModels.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_LibraryManagementSystem.API.DataModel.Helper;
using E_LibraryManagementSystem.ServiceModel.DTO.Request;
using E_LibraryManagementSystem.ServiceModel.DTO.Response;
using System.Net;

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

    

     

        public async Task<IEnumerable<RespRequestedBookDTO>> GetAllRequests()
        {
            //var data = await _LibraryManagementContext.RequestedBooks.ToListAsync();
            //return data;

            var reqListDTO = (from r in _LibraryManagementContext.RequestedBooks
                              join b in _LibraryManagementContext.BookDetails on r.BookId equals b.BookId
                              join u in _LibraryManagementContext.Users on r.UserId equals u.UserId
                              //join i in _LibraryManagementContext.IssuedBooks on r.BookId equals i.BookId

                              select new RespRequestedBookDTO
                              {
                                  BookName=b.BookName,
                                  UserId=u.UserId,
                                  AuthorName = b.AuthorName,
                                  ImageUrl=b.ImageUrl,
                                  BookId=b.BookId,
                                 // IssueDate=i.IssueDate,
                                  Name=u.Name,
                                //ReturnDate=i.ReturnDate,
                                  RequestId=r.RequestId
                              }).ToListAsync();


            return await reqListDTO;

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

            //status = 1;
           await _LibraryManagementContext.RequestedBooks.AddAsync(urequest);
            //var userEmail = _LibraryManagementContext.Users.Where(u => u.UserId == urequest.UserId).Select(s => s.Email).FirstOrDefault();
            //var adminEmail = _LibraryManagementContext.Users.Where(a => a.RoleId == 1).Select(x => x.Email).FirstOrDefault();

            //string sender =Convert.ToString(userEmail);
            //string receiver = Convert.ToString(adminEmail);
            
           // string receiver = Convert.ToString(userEmail);
           // string sender = "sachinmittalkod@gmail.com";
            

            

           // EmailService.smtpMailer(status,  sender, receiver, "");
            await _LibraryManagementContext.SaveChangesAsync();
            return 1;


        }

        //public bool UpdateRequest(RequestedBook urequest)
        //{
          
        //    _LibraryManagementContext.Update(urequest);
        //    _LibraryManagementContext.SaveChanges();
        //    return true;
        //}

        public async Task<int> DeleteRequest(int id)
        {
            var data = await _LibraryManagementContext.RequestedBooks.FindAsync(id);
            if (data == null)
            {
                return 0;
            }
            else
            _LibraryManagementContext.Remove(data);
           await _LibraryManagementContext.SaveChangesAsync();
         
            return 1;
        }
    }
}
