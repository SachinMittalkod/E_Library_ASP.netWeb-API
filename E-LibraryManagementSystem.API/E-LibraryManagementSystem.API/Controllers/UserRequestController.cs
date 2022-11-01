using AutoMapper;
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.API.Services.Interface;
using E_LibraryManagementSystem.ServiceModel.DTO.Request;
using E_LibraryManagementSystem.ServiceModel.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

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

        public async Task<ActionResult<IEnumerable<RespRequestedBookDTO>>> GetRequests()
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
        public async Task<ActionResult<int>> PostRequest([FromBody] RequestedBookDTO userRequest)
        {
            if (userRequest == null)
            {
                return NotFound();
            }
            var data=_mapper.Map<RequestedBook>(userRequest);
          await _userRequestService.MakeRequest(data);
            var mapping = _mapper.Map<RequestedBookDTO>(data);
            if (mapping == null)
            {
                return BadRequest();
            }
       
            return Ok("Request Sent");
        }   

        [HttpDelete]
        [Route("{requestId:int}")]
        public async Task<ActionResult> DeleteRequest(int requestId)
        {
            var deleteRequest = await _userRequestService.DeleteRequest(requestId);
            if (deleteRequest == 0)
            {
                return BadRequest("Please Enter valid id");
            }
            else
                return Ok("Deleted Successfully");
        }

     

   
 

   
    }
}
