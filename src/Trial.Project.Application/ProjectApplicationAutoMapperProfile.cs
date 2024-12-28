using AutoMapper;
using AutoMapper.Internal.Mappers;
using Trial.Project.Authors;
using Trial.Project.Books;

namespace Trial.Project;

public class ProjectApplicationAutoMapperProfile : Profile
{
    public ProjectApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<BookDto, CreateUpdateBookDto>();
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateUpdateAuthorDto, Author>();
        CreateMap<AuthorDto, CreateUpdateAuthorDto>();
    }
}
