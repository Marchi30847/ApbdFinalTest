using FinalTest.Contracts;
using FinalTest.Models;

namespace FinalTest.Mappers;

public static class BookMapper
{
    public static BookDto ToBookDto(this Book book)
    {
        return new BookDto
        {
            Id = book.IdBook,
            Name = book.Name,
            ReleaseDate = book.ReleaseDate,
            Genres = book.Genres
                .Select(g => g.Genre.ToGenreDto())
                .ToList(),
            Authors = book.Authors
                .Select(a => a.Author.ToAuthorDto())
                .ToList()
        };
    }
}