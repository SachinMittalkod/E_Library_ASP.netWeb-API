using AutoMapper;
using E_Library.DataModels.DTO;
using E_Library.DataModels.entities;

namespace E_Library.API.Mapper
{
    public class ProfileMapper:Profile
    {
        public ProfileMapper()
        {
            CreateMap<BookDetail, BookDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserRequest, UserRequestDTO>().ReverseMap();
        }
    }
}
