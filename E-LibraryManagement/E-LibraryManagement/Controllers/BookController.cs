using AutoMapper;
using E_LibraryManagement.DataModel.DTO;
using E_LibraryManagement.DataModel.entities;
using E_LibraryManagement.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetBook()
        {
            var data = _bookService.GetAllBookDetails();
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                var response = _mapper.Map<List<BookDTO>>(data);
                return Ok(response);
            }
        }


        [HttpPost]
        public ActionResult<int> PostBook([FromForm] BookDTO book)
        {
            var request = _mapper.Map<BookDetail>(book);
            var response = _bookService.AddBook(request);
            var mapRequest = _mapper.Map<BookDTO>(request);


            if (mapRequest == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(mapRequest);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<int> UpdateBook([FromRoute] int id,[FromForm] BookDTO bookDetail)
        {
            var mapRequest = _mapper.Map<BookDTO>(bookDetail);

            var book= _bookService.UpdateBook(id, bookDetail);
            if(mapRequest == null)
            {
                return BadRequest("The data is null");
            }
            else
            {
                return 1;
            }
           

        }


    }
}
