using E_Library.DataModels.entities;

namespace E_Library.API.Services.Interface
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDetail>> GetAllBookDetails();
        public Task<BookDetail> GetBookById(int id);
        Task<int> AddBook(BookDetail bookDetail);
        public bool UpdateBook(BookDetail bookDetail);
       
        public Task<int> DeleteBook(int id);
    }
}
