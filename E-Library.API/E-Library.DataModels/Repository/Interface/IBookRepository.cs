using E_Library.DataModels.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
