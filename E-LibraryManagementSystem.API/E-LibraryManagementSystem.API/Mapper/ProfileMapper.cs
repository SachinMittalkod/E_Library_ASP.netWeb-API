using AutoMapper;

using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.ServiceModel.DTO.Request;

namespace E_Library.API.Mapper
{
    public class ProfileMapper:Profile
    {
        public ProfileMapper()
        {
            CreateMap<BookDetail, BookDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<RequestedBook, RequestedBookDTO>().ReverseMap();
        }
    }
}
