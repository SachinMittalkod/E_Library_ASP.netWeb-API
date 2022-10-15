
using E_Library.DataModels.Repository.Interface;
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.API.Services.Interface;

namespace E_Library.API.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository )
        {
            _loginRepository = loginRepository;
        }



     

        public async Task<User> LoginUser(User login)
        {
            return await _loginRepository.LoginUser(login);
        }

        //public bool CheckUserAvailabity(string userName)
        //{
        //   return _loginRepository.CheckUserAvailabity(userName);
        //}

        //public bool isUserExists(int userId)
        //{
        //    return _loginRepository.isUserExists(userId);
        //}
    }
}
