using AutoMapper;
using E_LibraryManagementSystem.API.Services.Interface;
using E_LibraryManagementSystem.ServiceModel.DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_LibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuedBookController : ControllerBase
    {
        private readonly IIssuedBookService _issuedBookService;
        private readonly IMapper _mapper;
        public IssuedBookController(IIssuedBookService issuedBookService, IMapper mapper)
        {
            _issuedBookService = issuedBookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IssuedBookDTO>>> GetIssuedBook()
        {
            var issuedBooksDTO = await _issuedBookService.GetAllIssuedBook();
            

            if (issuedBooksDTO == null)
            {
                return NotFound("Not Issued any Book");
            }
            else
            {
                return Ok(issuedBooksDTO);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetIssuedBookById(int id)
        {
            var issuedBook = await _issuedBookService.GetIssuedBookById(id);

          

            if (issuedBook == null)
            {
                return NotFound("Book Not Found");
            }
            else
            {
                return Ok(issuedBook);
            }
        }


    }
}
