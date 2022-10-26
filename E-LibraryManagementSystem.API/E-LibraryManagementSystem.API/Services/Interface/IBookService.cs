


using E_LibraryManagementSystem.API.DataModel.Entities;

namespace E_LibraryManagementSystem.API.Services.Interface
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDetail>> GetAllBookDetails();
        public Task<BookDetail> GetBookById(int id);
        Task<int> AddBook(BookDetail bookDetail);
        public Task<bool> UpdateBook(BookDetail bookDetail);
       
        public Task<int> DeleteBook(int id);
    }
}
