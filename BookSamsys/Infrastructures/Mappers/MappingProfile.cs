using AutoMapper;
using BookSamsys.Infrastructures.Models.DTOs;
using BookSamsys.Infrastructures.Models;

namespace BookSamsys.Infrastructures.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>();

            CreateMap<BookDTO, Book>();

        }
    }
}
