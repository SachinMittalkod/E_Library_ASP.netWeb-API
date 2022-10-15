using E_LibraryManagementSystem.ServiceModel.DTO.Request;

namespace E_LibraryManagementSystem.API.Services.Interface
{
    public interface IIssuedBookService
    {
        Task<IEnumerable<IssuedBookDTO>> GetAllIssuedBook();

        public Task<List<IssuedBookDTO>> GetIssuedBookById(int id);
    }
}
