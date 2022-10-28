
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_Library.DataModels.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.DataModels.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly E_LibraryManagementContext _LibraryManagementContext;

        public BookRepository(E_LibraryManagementContext context)
        {
            _LibraryManagementContext = context;    
        }
        public async  Task<int> AddBook(BookDetail bookDetail)
        {
            await _LibraryManagementContext.BookDetails.AddAsync(bookDetail); 
            await _LibraryManagementContext.SaveChangesAsync();
            return 1;   
        }

     

        public async Task<bool> Save()
        {
            var saved =await _LibraryManagementContext.SaveChangesAsync();
            return  saved > 0 ? true : false;
        }

        public async Task<bool> UpdateBook(BookDetail bookDetail, int id)
        {
            var data = await _LibraryManagementContext.BookDetails.FindAsync(id);
            if(data == null)
            {
                return false;
            }
            else
            {
                data.BookName = bookDetail.BookName;
                data.AuthorName = bookDetail.AuthorName;
                data.Date = bookDetail.Date;
                data.ImageUrl = bookDetail.ImageUrl;
                _LibraryManagementContext.Entry(data).State = EntityState.Modified;
                await _LibraryManagementContext.SaveChangesAsync();
            }
          //  _LibraryManagementContext.Update(bookDetail);
            return true;
        }

        public async  Task<int> DeleteBook(int id)
        {
            
            var book = new BookDetail()
            {
                BookId = id
            };

             _LibraryManagementContext.Remove(book);
             _LibraryManagementContext.SaveChanges();
            return 1;
        }

        public async Task<IEnumerable<BookDetail>> GetAllBookDetails()
        {
            var data=await _LibraryManagementContext.BookDetails.ToListAsync();
            return data;
        }

        public async Task<BookDetail> GetBookById(int id)
        {
            BookDetail data =await _LibraryManagementContext.BookDetails.FirstOrDefaultAsync(x => x.BookId == id);
           

            if (data != null)
            {

                _LibraryManagementContext.Entry(data).State=EntityState.Detached;
                return data;

            }
            return null;

          
        }
    }
}
