using AutoMapper;
using E_LibraryManagement.DataModel.DTO;
using E_LibraryManagement.DataModel.entities;
using System.Runtime.InteropServices;

namespace E_LibraryManagement.Mapper
{
    public class ProfileMapper:Profile
    {
        public ProfileMapper()
        {
            CreateMap<BookDetail,BookDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

        }
    }
}
