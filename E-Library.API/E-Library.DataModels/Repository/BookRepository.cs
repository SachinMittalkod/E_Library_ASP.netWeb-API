using E_Library.DataModels.Entities;
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
        public  int AddBook(BookDetail bookDetail)
        {
             _LibraryManagementContext.BookDetails.Add(bookDetail); 
             _LibraryManagementContext.SaveChanges();
            return 1;   
        }

     

        public bool Save()
        {
            var saved = _LibraryManagementContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBook(BookDetail bookDetail)
        {
            _LibraryManagementContext.Update(bookDetail);
            return Save();
        }

        public  bool DeleteBook(int id)
        {
            var book = new BookDetail()
            {
                BookId = id
            };
            _LibraryManagementContext.Remove(book);
            _LibraryManagementContext.SaveChanges();
            return true;
        }
    }
}
