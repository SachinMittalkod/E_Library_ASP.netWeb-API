using E_Library.DataModels.entities;

namespace E_Library.API.Services.Interface
{
    public interface IBookService
    {
        public List<BookDetail> GetAllBookDetails();
        public BookDetail GetBookById(int id);
        public int AddBook(BookDetail bookDetail);
        public bool UpdateBook(BookDetail bookDetail);
        public bool DeleteBook(int id);
    }
}
