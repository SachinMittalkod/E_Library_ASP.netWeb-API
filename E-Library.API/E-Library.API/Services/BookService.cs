using AutoMapper;
using E_Library.API.Services.Interface;
using E_Library.DataModels.entities;
using E_Library.DataModels.Repository.Interface;

namespace E_Library.API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
           
        }
        public async Task<int> AddBook(BookDetail bookDetail)
        {
         return await _bookRepository.AddBook(bookDetail);
        }

        public bool UpdateBook(BookDetail bookDetail)
        {
            return _bookRepository.UpdateBook(bookDetail);
        }

        public async Task<int> DeleteBook(int id)
        {
            return await _bookRepository.DeleteBook(id);
        }

        public async Task<IEnumerable<BookDetail>> GetAllBookDetails()
        {
            return await _bookRepository.GetAllBookDetails();
        }

        public async Task<BookDetail> GetBookById(int id)
        {
            return await _bookRepository.GetBookById(id);
        }
    }
}
