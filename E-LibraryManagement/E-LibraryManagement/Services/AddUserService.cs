using E_LibraryManagement.DataModel.DTO;
using E_LibraryManagement.DataModel.entities;
using E_LibraryManagement.DataModel.Repository.Interface;
using E_LibraryManagement.Services.Interface;
using System.Threading.Tasks;




namespace E_LibraryManagement.Services
    {
        public class AddUserService : IAddUserService
        {
            private readonly IUserRepository _addUserRepository;
            public AddUserService(IUserRepository addUserRepository)
            {
                _addUserRepository = addUserRepository;
            }

            public Task<int> AddUser(User user)
            {
                return _addUserRepository.AddUser(user);
            }
        }
    }

