using E_Library.DataModels.entities;

namespace E_Library.API.Services.Interface
{
    public interface IUserService
    {
        public Task<int> RegisterUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);
    }
}
