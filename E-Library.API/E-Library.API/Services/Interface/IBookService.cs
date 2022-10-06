using E_Library.DataModels.Entities;

namespace E_Library.API.Services.Interface
{
    public interface IBookService
    {
        public int AddBook(BookDetail bookDetail);
        public bool UpdateBook(BookDetail bookDetail);
        public bool DeleteBook(int id);
    }
}
