using BookSamsys.Infrastructures.MessagingHelper;
using BookSamsys.Infrastructures.Models.DTOs;
using BookSamsys.Infrastructures.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookSamsys.Controllers
{

    [Route("api")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;

        public BooksController(BookService bookService)
        {
            _service = bookService;
        }

        [HttpGet("GetBooks")]
        public async Task<MessagingHelper<List<BookDTO>>> GetBooks()
        {
            return await _service.GetBooks();
        }
        
        // GET: api/books/isbn
        [HttpGet("Getbook/{isbn}")]

        public async Task<MessagingHelper<BookDTO>> GetBook(string isbn)
        {
            return await _service.GetBookByIsbn(isbn);
        }

        [HttpPost("CreateBook")]
        public async Task<MessagingHelper<BookDTO>> PostBook([FromBody] BookDTO bookDTO)
        {
            return await _service.PostBookAsync(bookDTO);
            
        }

        [HttpDelete("DeleteBook/{isbn}")]
        public async Task<MessagingHelper<BookDTO>> DeleteBook(string isbn)
        {
            return await _service.DeleteBook(isbn);
            
        }

        [HttpPut("EditBook/{isbn}")]
        public async Task<MessagingHelper<BookDTO>> EditBook(string isbn, [FromBody] EditBookDTO book)
        {
            return await _service.EditBook(isbn, book);
        }
    }
}
