using AutoMapper;
using E_LibraryManagement.DataModel.DTO;
using E_LibraryManagement.DataModel.entities;
using E_LibraryManagement.DataModel.Repository.Interface;
using E_LibraryManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserController : ControllerBase
    {
        private readonly IAddUserService _addUserService;
        IMapper _mapper;
        public UserController (IAddUserService addUserService, IMapper mapper)
	{
            _addUserService = addUserService;
            _mapper = mapper;   

    }
         
        [HttpPost]
        public async Task<ActionResult<int>> AddUser([FromForm]UserDTO user)
        {
            //Map<original model>(swagger input)
            var request = _mapper.Map<User>(user);
            var response=await _addUserService.AddUser(request);
            var mapperrequest = _mapper.Map<UserDTO>(request);
            if(response == null)
            {
                return BadRequest();

            }
            else
            {
                return Ok(mapperrequest);
            }
        }
        
    }
}
