using AutoMapper;
using BookSamsys.Infrastructures.Models.DTOs;
using BookSamsys.Infrastructures.Repository;

namespace BookSamsys.Infrastructures.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookService(BookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        public async Task<(List<BookDTO>, string)> GetBooks()
        {
            try
            {
                var livrosExistem = await _bookRepo.GetBooksAsync();

                if (livrosExistem == null || livrosExistem.Count == 0)
                {
                    // No books found
                    return (null, "Não existem livros na lista.");
                }
                else
                {
                    for (var i = 0; i < livrosExistem.Count; i++)
                    {
                        var book = livrosExistem[i].ISBN;
                    }

                    var livrosDTO = _mapper.Map<List<BookDTO>>(livrosExistem);
                    return (livrosDTO, "These are the books.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
