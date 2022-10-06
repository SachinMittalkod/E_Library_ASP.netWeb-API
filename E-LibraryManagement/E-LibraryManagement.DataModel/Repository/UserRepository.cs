using E_LibraryManagement.DataModel.DTO;
using E_LibraryManagement.DataModel.entities;
using E_LibraryManagement.DataModel.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagement.DataModel.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly E_LibraryManagementContext _context;
        public UserRepository(E_LibraryManagementContext LibraryContext)
        {
            _context = LibraryContext;
        }

        public async Task<int> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return 1;
        }

       
    }
}
