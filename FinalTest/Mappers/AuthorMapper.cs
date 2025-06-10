using FinalTest.Contracts;
using FinalTest.Models;

namespace FinalTest.Mappers;

public static class AuthorMapper
{
    public static AuthorDto ToAuthorDto(this Author author)
    {
        return new AuthorDto
        {
            Id = author.IdAuthor,
            FirstName = author.FirstName,
            LastName = author.LastName
        };
    }
}