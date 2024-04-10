using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace BookSamsys.Infrastructures.Models
{
    public class Book


    {
        [Key]
        public long id { get; set; }

        [Column(TypeName = "varchar (50)")]
        public string ISBN { get; set; }

        [Column(TypeName = "varchar (50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar (50)")]
        public string Author { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public void UpdateBook(string name, decimal price, string author)
        {
            Name = name;
            Price = price;
            Author = author;
        }
    }
}
