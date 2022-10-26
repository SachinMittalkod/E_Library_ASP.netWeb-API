using AutoMapper;
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.API.Services.Interface;
using E_LibraryManagementSystem.ServiceModel.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace E_LibraryManagementSystem.API.Controllers
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
        public async  Task<ActionResult<int>> RegisterUser([FromBody]UserDTO userDTO)
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
        
        public async Task<ActionResult> UpdateUser(int id,[FromBody]UserDTO userDTO)
        {
            if(userDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (id == null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //if (id != userDTO.UserId)
            //{
            //    return BadRequest(ModelState);
            //}
            var mapping=_mapper.Map<User>(userDTO);

            if (! await _userService.UpdateUser(mapping))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);

            }
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        { 
            _userService.DeleteUser(id);
            return Ok();    

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserDetails()
        {
            var data =await _userService.GetUserDetails();
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(data);
            }

        }

    }
}
