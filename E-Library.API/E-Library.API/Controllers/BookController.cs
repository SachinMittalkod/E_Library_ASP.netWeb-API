using AutoMapper;
using E_Library.API.Services;
using E_Library.API.Services.Interface;
using E_Library.DataModels.DTO;
using E_Library.DataModels.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<BookDTO> GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if(book == null)
            {
                return NotFound("The Entered ID not found");  
            }
            return Ok(book);
        }

        [HttpGet]
        public ActionResult< List<BookDetail>> GetBookDetails()
        {
            var data=_bookService.GetAllBookDetails();
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpPost]
        public ActionResult<int> PostBook([FromForm] BookDTO book)
        {
            var request=_mapper.Map<BookDetail>(book);
            var requestdata = _bookService.AddBook(request);
            var mapRequest=_mapper.Map<BookDTO>(request);
            if(mapRequest == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mapRequest);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromForm] BookDTO updatebookDTO)
        {
            if (updatebookDTO == null)
            {
                return BadRequest();
            }

            if(id != updatebookDTO.UserId)
            {
                return BadRequest(ModelState);
            }

            var mapping = _mapper.Map<BookDetail>(updatebookDTO);

            if (!_bookService.UpdateBook(mapping))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();


        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
