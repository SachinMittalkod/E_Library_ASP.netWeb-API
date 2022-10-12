using E_Library.DataModels.entities;

namespace E_Library.API.Services.Interface
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetUserDetails();
        public Task<int> RegisterUser(User user);
        public bool UpdateUser(User user);
        public Task<int> DeleteUser(int id);
        //public Task<User> LoginUser(User user);
    }
}
