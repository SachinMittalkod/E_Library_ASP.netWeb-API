using AutoMapper;

using E_Library.DataModels.Repository.Interface;
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.API.Services.Interface;

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

        public async Task<bool> UpdateBook(BookDetail bookDetail)
        {
            return await _bookRepository.UpdateBook(bookDetail);
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
