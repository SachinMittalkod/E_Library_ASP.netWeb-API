using E_Library.DataModels.DTO;
using E_Library.DataModels.entities;

namespace E_Library.API.Services.Interface
{
    public interface ILoginService
    {
        Task<User> LoginUser(User login);      
        //bool CheckUserAvailabity(string userName);

        //bool isUserExists(int userId);
    }
}
