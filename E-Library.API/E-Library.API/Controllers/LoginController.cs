using E_Library.API.Services.Interface;
using E_Library.DataModels.DTO;
using E_Library.DataModels.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ITokenService _tokenService;

        public LoginController(ILoginService loginService, ITokenService tokenService)
        {
            _loginService = loginService;
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginDTO loginDTO)
        {
            IActionResult response = Unauthorized("Invalid User");
            User user = await _loginService.AuthenticateUser(loginDTO);
            if(user != null)
            {
                var tokenString = _tokenService.CreateToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            return response;
        }
    }
}
