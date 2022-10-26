using AutoMapper;
using E_Library.API.Services;
using E_LibraryManagementSystem.API.DataModel.Entities;
using E_LibraryManagementSystem.API.Services.Interface;
using E_LibraryManagementSystem.ServiceModel.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_LibraryManagementSystem.API.Controllers
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
        //[Authorize(Policy = UserRoles.User)]
        public async Task<ActionResult<BookDTO>> GetBookById(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound("The Entered ID not found");
            }
            return Ok(book);
        }

        [HttpGet]
        [Route("GetBookDetails")]
       //[Authorize(Policy = UserRoles.Admin)]
        public async Task<ActionResult<IEnumerable<BookDetail>>> GetBookDetails()
        {
            var data = await _bookService.GetAllBookDetails();
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
        //[Route("api/PostBook")]
        public async  Task<ActionResult<int>> PostBook([FromBody] BookDTO bookDTO)
        {


            //var bookDetail = new BookDetail
            //{
            //    //BookId = bookDTO.BookId,
            //    AuthorName = bookDTO.AuthorName,
            //    BookName = bookDTO.BookName,
            //    Date = bookDTO.Date,
            //    ImageUrl = bookDTO.ImageUrl,
            //    UserId = bookDTO.UserId

            //};
            //return await _bookService.AddBook(bookDetail);
            var request = _mapper.Map<BookDetail>(bookDTO);
            var responce = await _bookService.AddBook(request);
            var mapping = _mapper.Map<BookDTO>(request);

            if (mapping == null)
            {
                return BadRequest();
            }
            return Ok(responce);
        }

        [HttpPut("{id}")]
       
        public async Task<ActionResult<bool>> UpdateBook(int id, [FromForm] BookDTO updatebookDTO)
        {
            if (updatebookDTO == null)
            {
                
                return BadRequest();
            }

            //if (id != updatebookDTO.BookId)
            //{
            //    return BadRequest(ModelState);
            //}


            var mapping = _mapper.Map<BookDetail>(updatebookDTO);
                
            if (!await _bookService.UpdateBook(mapping))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteBook(int id)
        {
           await _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
