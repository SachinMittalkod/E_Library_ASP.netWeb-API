using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.API.DataModel.Repository.Interface;
using E_LibraryManagementSystem.ServiceModel.DTO.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagementSystem.API.DataModel.Repository
{
    public class IssuedBookRepositiry:IIssuedBookRepository
    {
        private readonly E_LibraryManagementContext _LibraryManagementContext;

        public IssuedBookRepositiry(E_LibraryManagementContext e_LibraryManagementContext)
        {
            _LibraryManagementContext = e_LibraryManagementContext;
        }

        public async Task<IEnumerable<IssuedBookDTO>> GetAllIssuedBook()
        {
            var issuedBooks = (from i in _LibraryManagementContext.IssuedBooks
                               join b in _LibraryManagementContext.BookDetails on i.BookId equals b.BookId
                               join u in _LibraryManagementContext.Users on i.UserId equals u.UserId

                               select new IssuedBookDTO
                               {
                                   IssuedId=i.IssueId,
                                   UserId=u.UserId,
                                   BookId=b.BookId,
                                   UserName=u.Name,
                                   BookName=b.BookName,
                                   IssueDate=i.IssueDate,
                                   ReturnDate=i.ReturnDate
                                   
                               }).ToListAsync();
            return await issuedBooks;
        }

        public async Task<List<IssuedBookDTO>> GetIssuedBookById(int id)
        {
            var issuedBookDTO = (from i in _LibraryManagementContext.IssuedBooks
                                 join b in _LibraryManagementContext.BookDetails on i.BookId equals b.BookId
                                 join u in _LibraryManagementContext.Users on i.UserId equals u.UserId

                                 select new IssuedBookDTO
                                 {
                                     IssuedId = i.IssueId,
                                     UserId = u.UserId,
                                     BookId = b.BookId,
                                     UserName = u.Name,
                                     BookName = b.BookName,
                                     IssueDate = i.IssueDate,
                                     ReturnDate = i.ReturnDate
                                 }).ToList();

            var data = issuedBookDTO.Where(x => x.UserId == id || x.IssuedId == id).Select(x => x).ToList();
            return data;

        }

 
    }
}
