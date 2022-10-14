﻿using E_Library.DataModels.entities;

namespace E_Library.API.Services.Interface
{
    public interface ITokenRepository
    {
        Task<String> CreateToken(User user);
    }
}
