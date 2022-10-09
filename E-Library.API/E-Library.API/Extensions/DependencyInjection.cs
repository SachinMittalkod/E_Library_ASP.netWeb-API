using E_Library.API.Mapper;
using E_Library.API.Services.Interface;
using E_Library.API.Services;
using E_Library.DataModels.Repository.Interface;
using E_Library.DataModels.Repository;

namespace E_Library.API.Extensions
{
    public static class DependencyInjection
    {
        public static void ConfigureDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            //builder.Services.AddAutoMapper(typeof(ProfileMapper));
            //builder.Services.AddScoped<IBookRepository, BookRepository>();
            //builder.Services.AddScoped<IBookService, BookService>();
            //builder.Services.AddScoped<IUserRepository, UserRepository>();
            //builder.Services.AddScoped<IUserService, UserService>();
            //builder.Services.AddScoped<IUserRequestService, UserRequestService>();
            //builder.Services.AddScoped<IUserRequestRepository, UserRequestRepository>();

        }
}
}
