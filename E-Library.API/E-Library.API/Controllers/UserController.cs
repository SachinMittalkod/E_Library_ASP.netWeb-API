using AutoMapper;
using E_Library.API.Services.Interface;
using E_Library.DataModels.DTO;
using E_Library.DataModels.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService=userService;
            _mapper=mapper;
        }

        [HttpPost]
        public async  Task<ActionResult<int>> RegisterUser([FromForm]UserDTO userDTO)
        {
            var request = _mapper.Map<User>(userDTO);
            var responce=await _userService.RegisterUser(request);
            var mapping=_mapper.Map<UserDTO>(request);

            if (mapping == null)
            {
                return BadRequest();
            }
            return Ok(responce);
        }

        [HttpPut("{id}")]
        public  ActionResult UpdateUser(int id,[FromForm]UserDTO userDTO)
        {
            if(userDTO == null)
            {
                return BadRequest();
            }
            if(id != userDTO.UserId)
            {
                return BadRequest(ModelState);
            }
            var mapping=_mapper.Map<User>(userDTO);

            if (!_userService.UpdateUser(mapping))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);

            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        { 
            _userService.DeleteUser(id);
            return Ok();    

        }
    }
}
