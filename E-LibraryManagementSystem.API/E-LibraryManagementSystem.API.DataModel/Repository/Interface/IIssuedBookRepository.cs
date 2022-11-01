using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.ServiceModel.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagementSystem.API.DataModel.Repository.Interface
{
    public interface IIssuedBookRepository
    {
        public Task<IEnumerable<IssuedBookDTO>> GetAllIssuedBook();
        public Task<List<IssuedBookDTO>> GetIssuedBookById(int id);

        Task<int> AcceptRequest(IssuedBook issuedBook);
    }
}
