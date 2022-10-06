using E_LibraryManagement.DataModel.DTO;
using E_LibraryManagement.DataModel.entities;
using E_LibraryManagement.DataModel.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_LibraryManagement.DataModel.Repository
{

    public class BookRepository :IBookRepository
    {
        //IEnumerable:-Fetching data from Collections
        //IQueryable:-Fetching data from database

        private readonly E_LibraryManagementContext _LibraryManagement;
        public BookRepository(E_LibraryManagementContext e_LibraryManagementContext)
        {
            _LibraryManagement = e_LibraryManagementContext;
        }




         List<BookDetail> IBookRepository.GetAllBookDetails()
        {
            var data = _LibraryManagement.BookDetails.Select(x=>x).ToList();
            return data;
        }

    

     

        public int AddBook(BookDetail bookDetail)
        {
             _LibraryManagement.BookDetails.Add(bookDetail);
             _LibraryManagement.SaveChanges();
            return 1;
        }

        public async Task<int> UpdateBook(int BookId, BookDTO bookDetail)
        {
            //UpdateBook(int BookId, BookDetail bookDetail)
            //here we are searching data from data base and stored in the book variable(Existing data)
            var book =await _LibraryManagement.BookDetails.FindAsync(BookId);
          //we are checking using if condition, if 
            if(book != null)
            {
                book.BookId = bookDetail.BookId;
                book.BookName = bookDetail.BookName;
                book.AuthorName = bookDetail.AuthorName;    
                book.Date= bookDetail.Date;

              return await _LibraryManagement.SaveChangesAsync();
             
                

            }
            return 1;
        }
    }
}


