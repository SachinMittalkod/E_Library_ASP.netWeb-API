using E_LibraryManagement.DataModel.DTO;
using E_LibraryManagement.DataModel.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LibraryManagement.Services.Interface
{
    public interface IBookService
    {
        public List<BookDetail> GetAllBookDetails();
        public int AddBook(BookDetail bookDetail);
        public Task<int> UpdateBook(int BookId, BookDTO bookDetail);
        
    }
}
