using FinalTest.Contracts;
using FinalTest.Models;

namespace FinalTest.Mappers;

public static class GenreMapper
{
    public static GenreDto ToGenreDto(this Genre genre)
    {
        return new GenreDto
        {
            Id = genre.IdGenre,
            Name = genre.Name
        };
    }
}