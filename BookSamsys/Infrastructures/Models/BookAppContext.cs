using Microsoft.EntityFrameworkCore;

namespace BookSamsys.Infrastructures.Models
{
    public class BookAppContext : DbContext
    {
        public BookAppContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
