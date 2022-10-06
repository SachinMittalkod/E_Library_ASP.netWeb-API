using E_LibraryManagement.DataModel.DTO;
using E_LibraryManagement.DataModel.entities;
using E_LibraryManagement.DataModel.Repository;
using E_LibraryManagement.DataModel.Repository.Interface;
using E_LibraryManagement.Services.Interface;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace E_LibraryManagement.Services
{
    public class BookService : IBookService

    {
     
        private readonly IBookRepository _BookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _BookRepository =bookRepository;
        }
        public   int AddBook(BookDetail bookDetail)
        {

            return   _BookRepository.AddBook(bookDetail);
        }

        public List<BookDetail> GetAllBookDetails()
        {
            return _BookRepository.GetAllBookDetails();
        }

        public async Task<int> UpdateBook(int BookId, BookDTO bookDetail)
        {

            await _BookRepository.UpdateBook(BookId, bookDetail);
            return 1;
        }

      
    }
}
