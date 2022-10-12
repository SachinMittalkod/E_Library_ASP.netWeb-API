using E_Library.API.Services.Interface;
using E_Library.DataModels.entities;
using E_Library.DataModels.Repository;
using E_Library.DataModels.Repository.Interface;

namespace E_Library.API.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public Task<IEnumerable<User>> GetUserDetails()
        {
            return _userRepository.GetUserDetails();
        }

        public async Task<int> RegisterUser(User user)
        {
           await _userRepository.RegisterUser(user);
            return 1;
        }

        public bool UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            return true;
        }

        //public async Task<User> LoginUser(User user)
        //{
        //    return await _userRepository.LoginUser(user);
        //}


    }
}
