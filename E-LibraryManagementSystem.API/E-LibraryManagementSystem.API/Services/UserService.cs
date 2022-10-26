using E_Library.DataModels.Repository.Interface;
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.API.Services.Interface;

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

        public async Task<bool> UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user);
            return true;
        }

       

    }
}
