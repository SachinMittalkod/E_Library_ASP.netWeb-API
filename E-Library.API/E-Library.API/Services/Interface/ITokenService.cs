using E_Library.DataModels.entities;

namespace E_Library.API.Services.Interface
{
    public interface ITokenService
    {
        string CreateToken(User userInfo);
    }
}
