using E_LibraryManagementSystem.API.DataModel.Entities;

namespace E_Library.API.Services.Interface
{
    public interface ITokenRepository
    {
        Task<String> CreateToken(User user);

    }
}
