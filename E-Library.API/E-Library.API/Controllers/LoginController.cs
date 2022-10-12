using E_Library.API.Services.Interface;
using E_Library.DataModels.DTO;
using E_Library.DataModels.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
       

    public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
            
        }

        [HttpPost]
        public async Task<ActionResult<User>> LoginUser([FromForm]LoginDTO logindata)
        {
            var data = new User
            {
                Name=logindata.Name,
                Password=logindata.Password
            };

            var result= await _loginService.LoginUser(data);
            if (result != null)
            {
                return Ok("Login Success");
            }
            else
            {
                return BadRequest("Invalid credentials or Enter Values");
            }
        }
       
    }
}
