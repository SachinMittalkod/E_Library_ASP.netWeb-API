using E_Library.API.Mapper;
using E_Library.API.Services;
using E_Library.API.Services.Interface;
using E_Library.DataModels.Entities;
using E_Library.DataModels.Repository;
using E_Library.DataModels.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<E_LibraryManagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDb"))); 

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(ProfileMapper));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
