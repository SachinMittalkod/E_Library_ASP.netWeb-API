

using E_LibraryManagementSystem.API.DataModel.Entities;

namespace E_LibraryManagementSystem.API.Services.Interface
{
    public interface ILoginService
    {
        Task<User> LoginUser(User login);      
        //bool CheckUserAvailabity(string userName);

        //bool isUserExists(int userId);
    }
}
