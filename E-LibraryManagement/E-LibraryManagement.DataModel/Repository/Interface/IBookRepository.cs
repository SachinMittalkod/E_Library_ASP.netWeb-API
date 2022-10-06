using E_LibraryManagement.DataModel.DTO;
using E_LibraryManagement.DataModel.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagement.DataModel.Repository.Interface
{
    public interface IBookRepository
    {
        //Need to have data
        public List<BookDetail> GetAllBookDetails();
        public int AddBook(BookDetail bookDetail);

 
        public Task<int> UpdateBook(int bookId, BookDTO bookDetail);
    }
}
