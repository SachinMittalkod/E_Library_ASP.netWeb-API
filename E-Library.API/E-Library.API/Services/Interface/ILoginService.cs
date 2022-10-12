using E_Library.DataModels.DTO;
using E_Library.DataModels.entities;

namespace E_Library.API.Services.Interface
{
    public interface ILoginService
    {
        public Task<User> LoginUser(User user);
    }
}
