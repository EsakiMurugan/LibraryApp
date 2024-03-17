using AutoMapper;
using LibraryApp.DTO;
using LibraryApp.Model;

namespace LibraryApp.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>().ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher))
                                      .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => $"{src.AuthorLastName}, {src.AuthorFirstName}"))
                                      .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                                      .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

        }
    }
}
