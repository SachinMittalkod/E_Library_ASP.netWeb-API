using E_Library.API.Mapper;
using E_Library.API.Services.Interface;
using E_Library.API.Services;
using E_Library.DataModels.Repository.Interface;
using E_Library.DataModels.Repository;
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.API.DataModel.Repository;
using E_LibraryManagementSystem.API.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using E_LibraryManagementSystem.API.DataModel.Repository.Interface;
using E_LibraryManagementSystem.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<E_LibraryManagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDb")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(typeof(ProfileMapper));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRequestService, UserRequestService>();
builder.Services.AddScoped<IUserRequestRepository, UserRequestRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddScoped<IIssuedBookRepository, IssuedBookRepositiry>();
builder.Services.AddScoped<IIssuedBookService, IssuedBookService>();



builder.Services.AddScoped<ITokenRepository, TokenRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        });
builder.Services.AddAuthorization(config =>
{
    config.AddPolicy(UserRoles.Admin, Policies.AdminPolicy());
    config.AddPolicy(UserRoles.User, Policies.UserPolicy());
});

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoAPI v1", Version = "v1" });
//    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
//    {
//        Description = "Standard JWT Authorization header. Example: \"bearer {token}\"",
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.ApiKey

//    });
//    c.OperationFilter<SecurityRequirementsOperationFilter>();
//   // builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
//});
builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter a valis JWT bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[]{ } }
    });
});

//builder.Services.AddCors(c =>
//{
//    //if specific domain to access use withOrigins
//    //Angular Application Policy name
//    c.AddPolicy("Angular Application", builder => { builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader(); });
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
