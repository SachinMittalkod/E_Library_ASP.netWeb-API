using E_Library.API.Services.Interface;

using E_LibraryManagementSystem.API.DataModel.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_LibraryManagementSystem.API.DataModel.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;

        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> CreateToken(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.Name));
            claims.Add(new Claim(ClaimTypes.Role, user.Gender));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            //libUser.Role.ForEach((role) =>
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, (string)role));

            //});

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
