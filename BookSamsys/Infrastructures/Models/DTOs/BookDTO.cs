namespace BookSamsys.Infrastructures.Models.DTOs
{
    public class BookDTO
    {
        public string ISBN { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }
    }

    public class EditBookDTO
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }
    }
}
