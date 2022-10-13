using AutoMapper;
using E_Library.API.Services;
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
        public async Task<ActionResult<BookDTO>> GetBookById(int id)
        {
            var book =await _bookService.GetBookById(id);
            if(book == null)
            {
                return NotFound("The Entered ID not found");  
            }
            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDetail>>> GetBookDetails()
        {
            var data=await _bookService.GetAllBookDetails();
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
        public async  Task<ActionResult<int>> PostBook([FromForm] BookDTO bookDTO)
        {
            //var request=_mapper.Map<BookDetail>(book);
            //var requestdata = _bookService.AddBook(request);
            //var mapRequest=_mapper.Map<BookDTO>(request);

            var bookDetail = new BookDetail
            {
                BookId = bookDTO.BookId,
                AuthorName = bookDTO.AuthorName,
                BookName = bookDTO.BookName,
                Date = bookDTO.Date,
                ImageUrl = bookDTO.ImageUrl,
                UserId = bookDTO.UserId
             
            };
            return await _bookService.AddBook(bookDetail);      
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromForm] BookDTO updatebookDTO)
        {
            if (updatebookDTO == null)
            {
                
                return BadRequest();
            }

            if (id != updatebookDTO.BookId)
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
