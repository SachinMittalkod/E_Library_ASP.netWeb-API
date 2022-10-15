
using E_LibraryManagementSystem.API.DataModel.Entities;

namespace E_Library.DataModels.Repository.Interface
{
    public interface IBookRepository
    {
        public Task<IEnumerable<BookDetail>> GetAllBookDetails();

        public Task<BookDetail> GetBookById(int id);
        Task<int> AddBook(BookDetail bookDetail);
        public bool UpdateBook(BookDetail bookDetail);
        public Task<int> DeleteBook(int id);
        bool Save();

        
    }
}
