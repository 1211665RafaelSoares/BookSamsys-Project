using AutoMapper;
using Azure;
using BookSamsys.Infrastructures.MessagingHelper;
using BookSamsys.Infrastructures.Models;
using BookSamsys.Infrastructures.Models.DTOs;
using BookSamsys.Infrastructures.Repository;
using System.Net;

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

        public async Task<MessagingHelper<List<BookDTO>>> GetBooks()
        {
            MessagingHelper<List<BookDTO>> response = new();
            try
            {
                var livrosExistem = await _bookRepo.GetBooksAsync();

                if (livrosExistem == null || livrosExistem.Count == 0)
                {
                    // No books found
                    response.Message = "Não existe livros na lista";
                    return response;
                }
                else
                {
                    for (var i = 0; i < livrosExistem.Count; i++)
                    {
                        var book = livrosExistem[i].ISBN;
                    }

                    var livrosDTO = _mapper.Map<List<BookDTO>>(livrosExistem);
                    response.Message = "Lista de Livros fornecida com sucesso!";
                    response.Obj = livrosDTO;
                    response.Success = true;
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<MessagingHelper<BookDTO>> GetBookByIsbn(string isbn)
        {
            MessagingHelper<BookDTO> response = new();
            try
            {
                if (isbn.Length != 13 )
                {
                    response.Message = "O ISBN necessita de ter 13 Caracteres";
                    return response;
                } 

                var livroExiste = await _bookRepo.GetBookByISBN(isbn);
                if (livroExiste == null)
                {
                    response.Message = "O Livro não existe";
                    return response;
                }
                BookDTO livroInfoDTO = _mapper.Map<BookDTO>(livroExiste);
                response.Message = "Livro encontrado";
                response.Obj = livroInfoDTO;    
                response.Success = true;
                return response;

            } catch (Exception) 
            {
                response.Message = "Erro";
                response.Success= false;
                return response;
            }
   
        }

        public async Task<MessagingHelper<BookDTO>> PostBookAsync(BookDTO bookDTO)
        {
            MessagingHelper<BookDTO> response = new();
            try
            {
                var livroFind = await _bookRepo.GetBookByISBN(bookDTO.ISBN);



                if (livroFind == null)
                {
                    if (bookDTO.ISBN.Length == 13 && bookDTO.Name.Length > 1 && bookDTO.Price > 0)
                    {


                        var mappedBook = _mapper.Map<Book>(bookDTO);
                        var bookAdd = await _bookRepo.PostNewBook(mappedBook);
                        response.Message = "Livro criado com sucesso";
                        response.Obj = bookDTO;
                        response.Success = true;
                        return response;

                    }

                    response.Message = "Preencha os campos obrigatórios de forma correta";
                    return response;
                }

                response.Message = "Livro já existente";
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<MessagingHelper<BookDTO>> DeleteBook(string isbn)
        {
            MessagingHelper<BookDTO> response = new();
            try
            {
                if (isbn.Length != 13)
                {
                    response.Message = "O ISBN necessita de ter 13 Caracteres";
                    return response;
                }

                var book = await _bookRepo.GetBookByISBN(isbn);

                if (book == null)
                {
                    response.Message = "O Livro não existe";
                    return response;
                } else
                {
                    var removeBook = await _bookRepo.RemoveBook(isbn);
                    var mappedBook = _mapper.Map<BookDTO>(removeBook);
                    response.Message = "Livro removido com sucesso";
                    response.Obj = mappedBook;
                    response.Success = true;
                    return response;
                }
            } 
            catch (Exception)
            {
                response.Message = "Erro";
                return response;
            }
        }

        public async Task<MessagingHelper<BookDTO>> EditBook(string isbn, EditBookDTO bookDTO)
        {
            MessagingHelper<BookDTO> response = new();
            try
            {
                if (isbn.Length != 13) {
                    response.Message = "O ISBN precisa ter 13 caracteres";
                    return response;
                }
                Book bookExists = await _bookRepo.GetBookByISBN(isbn);
                if (bookExists == null)
                {
                    response.Message = "Livro não existe";
                    return response;
                } else
                {
                    if (bookDTO.Name.Length <= 1 || bookDTO.Price <= 0 || bookDTO.Author.Length <= 1)
                    {
                        response.Message = "Preencha os campos obrigatórios de forma correta";
                        return response;
                    }
                    bookExists.UpdateBook(bookDTO.Name, bookDTO.Price, bookDTO.Author);
                    Book bookEdited = await _bookRepo.EditBook(bookExists);

                    response.Message = "Livro editado com sucesso";
                    response.Obj = _mapper.Map<BookDTO>(bookEdited);
                    response.Success = true;
                    return response;
                }

            }
            catch (Exception)
            {
                response.Message = "Error";
                return response;
            }
        }
    }
}
