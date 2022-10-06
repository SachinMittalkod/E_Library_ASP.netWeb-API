using E_Library.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.DataModels.Repository.Interface
{
    public interface IBookRepository
    {
        public int AddBook(BookDetail bookDetail);   
        public bool UpdateBook(BookDetail bookDetail);
        
        public bool DeleteBook(int id);
        bool Save();

    }
}
