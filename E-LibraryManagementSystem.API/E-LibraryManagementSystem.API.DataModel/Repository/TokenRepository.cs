using E_Library.API.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
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
        public readonly SymmetricSecurityKey _symmetricSecurityKey;
        private readonly IConfiguration configuration;

        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> CreateToken(User user)
        {
            var claims = new List<Claim>() {
            new Claim(JwtRegisteredClaimNames.Sub, user.Name),
              new Claim("userid", user.UserId.ToString()),
                new Claim("userTypeId", user.Name.ToString()),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            //var claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.GivenName, user.Name));
            //claims.Add(new Claim(ClaimTypes.Role, user.Gender));
            //claims.Add(new Claim(ClaimTypes.Email, user.Email));
            //new Claim(ClaimTypes.Role, user.RoleId.ToString());




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
