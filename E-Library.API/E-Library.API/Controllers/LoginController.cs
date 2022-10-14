using AutoMapper;
using E_Library.API.Services;
using E_Library.API.Services.Interface;
using E_Library.DataModels.DTO;
using E_Library.DataModels.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;
 
        public LoginController( ILoginService loginService, IMapper mapper, ITokenRepository tokenRepository)
        { 
            _loginService = loginService;
            _mapper = mapper;
            _tokenRepository = tokenRepository; 


        }

        [HttpPost]
        public async Task<ActionResult> LoginUser([FromBody] LoginDTO loginDTO)
        {
            var libUser = new User
            {
                Name = loginDTO.Name,
                Password = loginDTO.Password
            };

            var user = await _loginService.LoginUser(libUser);

            if (user != null)
            {
                var token = _tokenRepository.CreateToken(user);
                return Ok(token);
            }
            else
            {
                return BadRequest("Login Failed Invalid Credential");
            }

        }

    }
}
