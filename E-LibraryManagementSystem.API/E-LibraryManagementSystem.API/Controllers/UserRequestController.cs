using AutoMapper;
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.API.Services.Interface;
using E_LibraryManagementSystem.ServiceModel.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace E_LibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRequestController : ControllerBase
    {
        private readonly IUserRequestService _userRequestService;
        IMapper _mapper;
        public UserRequestController(IUserRequestService userRequestService, IMapper mapper)
        {
            _userRequestService = userRequestService;
            _mapper = mapper;
        }


        [HttpGet]   

        public async Task<ActionResult<IEnumerable<UserRequest>>> GetAllRequests()
        {
            var data= await _userRequestService.GetAllRequests();
            if(data==null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPost]
        //MakeRequest Method
        public ActionResult<int> PostRequest([FromForm]UserRequestDTO userRequest)
        {
            var data=_mapper.Map<UserRequest>(userRequest);
            var response= _userRequestService.MakeRequest(data);
            var mapping=_mapper.Map<UserRequestDTO>(data);
            if(mapping == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

     

        [HttpPut("{id}")]
        public ActionResult UpdateRequest(int id, [FromForm]UserRequestDTO userRequestDTO)
        {
            if (userRequestDTO == null)
            {
                return BadRequest();
            }
            if (id != userRequestDTO.RequestId)
            {
                return BadRequest(ModelState);
            }
            var mapping = _mapper.Map<UserRequest>(userRequestDTO);

            if (!_userRequestService.UpdateRequest(mapping))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //[HttpGet]

        //public ActionResult<int> GetNoOfRequests()
        //{
        //    var data = _userRequestService.GetNoOfRequests();
          
        //    return data;
        //}
    }
}
