using AutoMapper;

using E_Library.DataModels.entities;
using E_Library.DataModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.DataModels.Repository
{
   

    public class UserRepository : IUserRepository
    {
        private readonly E_LibraryManagementContext _LibraryManagementContext;
        IMapper _mapper;
        public UserRepository(E_LibraryManagementContext e_LibraryManagementContext)
        {
            _LibraryManagementContext = e_LibraryManagementContext;
            
        }

        

        public async Task<int> RegisterUser(User user)
        {
        await _LibraryManagementContext.Users.AddAsync(user);
        await _LibraryManagementContext.SaveChangesAsync();
            return 1;
        }

        public bool Save()
        {
            var saved = _LibraryManagementContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public  bool UpdateUser(User user)
        {
             _LibraryManagementContext.Update(user);
             return Save();
        }

        public bool DeleteUser(int id)
        {
           var Deleteuser=new User()
           {
               UserId= id
           };
         _LibraryManagementContext.Users.Remove(Deleteuser);
            _LibraryManagementContext.SaveChanges();
            return true;
        }
    }
}
