using Microsoft.AspNetCore.Mvc;
using BookSamsys.Infrastructures.Models;

namespace BookSamsys.Infrastructures.Repository
{
    public class BookRepository
    {
        private readonly BookAppContext _context;

        public BookRepository(BookAppContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var books = _context.Books.ToList();
            return books;
        }


    }
}
