using Microsoft.AspNetCore.Mvc;
using BookSamsys.Infrastructures.Models;
using System.Data.Entity;

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

        public async Task<Book> GetBookByISBN(string isbn)
        {
            var book = _context.Books.FirstOrDefault(b => b.ISBN == isbn);
            return book;
        }

        public async Task<Book> PostNewBook([FromBody] Book newBook)
        {
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }

        public async Task<Book> RemoveBook(string isbn)
        {
            var book = _context.Books.FirstOrDefault(b => b.ISBN == isbn);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> EditBook(Book bookExists)
        {
            _context.Entry<Book>(bookExists).CurrentValues.SetValues(bookExists);
            await _context.SaveChangesAsync();
            return bookExists;
        }

        public async Task<int> GetTotalNumberOfBooksAsync()
        {
            return await _context.Books.CountAsync();
        }

        public async Task<List<Book>> GetBooksAsync(int pageNumber, int pageResults)
        {
            var books = _context.Books
                .Skip((pageNumber - 1) * pageResults)
                .Take(pageResults);
            return await books.ToListAsync();
        }
    } 
}
