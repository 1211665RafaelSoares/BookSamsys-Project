using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
    }
}
