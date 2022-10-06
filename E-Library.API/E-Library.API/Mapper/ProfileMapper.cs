using AutoMapper;
using E_Library.DataModels.DTO;
using E_Library.DataModels.Entities;

namespace E_Library.API.Mapper
{
    public class ProfileMapper:Profile
    {
        public ProfileMapper()
        {
            CreateMap<BookDetail, BookDTO>().ReverseMap();
        }
    }
}
