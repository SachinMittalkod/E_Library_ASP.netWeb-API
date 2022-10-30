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

        public async Task<ActionResult<IEnumerable<RequestedBook>>> GetAllRequests()
        {
            var data= await _userRequestService.GetAllRequests();
            if(data==null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("PostRequest")]
        //MakeRequest Method
        public ActionResult<int> PostRequest([FromBody] RequestedBookDTO userRequest)
        {
            var data=_mapper.Map<RequestedBook>(userRequest);
            var response= _userRequestService.MakeRequest(data);
            var mapping=_mapper.Map<RequestedBookDTO>(data);
            if(mapping == null)
            {
                return BadRequest();
            }
            return Ok();
        }

     

   
 

   
    }
}
