﻿using E_Library.API.Services.Interface;
using E_Library.DataModels.DTO;
using E_Library.DataModels.entities;
using E_Library.DataModels.Repository.Interface;

namespace E_Library.API.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

     

        public async Task<User> LoginUser(User user)
        {
            return await _loginRepository.LoginUser(user);
        }
    }
}