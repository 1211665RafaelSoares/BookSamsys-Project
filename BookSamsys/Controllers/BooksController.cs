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

        [HttpGet("livros")]
        public async Task<List<BookDTO>> GetBooks()
        {
            var (books, _) = await _service.GetBooks();
            return books;
        }
    }
}
