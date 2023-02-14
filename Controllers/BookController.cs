using AutoMapper;
using BookShop.Dto;
using BookShop.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        public BookService _bookService;
       // private readonly IMapper mapper;
        public BookController(BookService bookService) 
        
        { 
            _bookService = bookService; 
            //mapper = Map;
        
        }

        [HttpGet("get-all")]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetBooks();
            return Ok(books);
        }

        [HttpGet("get-byId/{Id}")]
        public IActionResult GetBookById(int Id)
        {
            var book = _bookService.GetBookById(Id);
            return Ok(book);
        }


        [HttpPost("add-book")]
        public IActionResult AddBook(BookModel book)
        {
             _bookService.AddBookRepo(book);
              return Ok();  
        }

        [HttpPut("update-book")]

        public IActionResult UpdateBook(int bookId, BookModel book)
        {
            _bookService.UpdateBookRepo(bookId,book);
            return Ok();
        }

        [HttpDelete("delete-book/{Id}")]

        public IActionResult DeleteBook(int Id)
        {
            _bookService.DeleteBookById(Id);
            return Ok();
        }

    }
}
