using E_LibraryManagementSystem.API.DataModel.Repository.Interface;
using E_LibraryManagementSystem.API.Services.Interface;
using E_LibraryManagementSystem.ServiceModel.DTO.Request;

namespace E_LibraryManagementSystem.API.Services
{
    public class IssuedBookService : IIssuedBookService
    {
        private readonly IIssuedBookRepository _issuedBookRepository;

        public IssuedBookService(IIssuedBookRepository issuedBookRepository)
        {
            _issuedBookRepository = issuedBookRepository;
        }
        public Task<IEnumerable<IssuedBookDTO>> GetAllIssuedBook()
        {
           return _issuedBookRepository.GetAllIssuedBook();
        }

        public Task<List<IssuedBookDTO>> GetIssuedBookById(int id)
        {
            return _issuedBookRepository.GetIssuedBookById(id);
        }
    }
}
