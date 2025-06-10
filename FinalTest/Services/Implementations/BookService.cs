using FinalTest.Contracts;
using FinalTest.Contracts.Requests;
using FinalTest.Database;
using FinalTest.Exceptions;
using FinalTest.Mappers;
using FinalTest.Models;
using FinalTest.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinalTest.Services.Implementations;

public class BookService : IBookService
{
    private readonly AppDbContext _db;

    public BookService(AppDbContext db) => _db = db;

    public async Task<BookDto> CreateBookAsync(CreateBookRequest request)
    {
        var publishingHouse = await _db.PublishingHouses.FindAsync(request.PublishingHouseId);
        if (publishingHouse == null)
            throw new PublishingHouseNotFoundException(request.PublishingHouseId);

        var authors = await _db.Authors
            .Where(a => request.AuthorIds.Contains(a.IdAuthor))
            .ToListAsync();
        if (authors.Count != request.AuthorIds.Count)
            throw new AuthorNotFoundException();

        var genreEntities = new List<Genre>();
        foreach (var g in request.Genres)
        {
            Genre? genre = null;
            if (g.Id != 0)
                genre = await _db.Genres.FindAsync(g.Id);
            if (genre == null)
                genre = await _db.Genres.FirstOrDefaultAsync(x => x.Name == g.Name);

            if (genre == null)
            {
                genre = new Genre { Name = g.Name };
                _db.Genres.Add(genre);
            }

            genreEntities.Add(genre);
        }

        var bookAuthors = authors
            .Select(a => new BookAuthor { IdAuthor = a.IdAuthor })
            .ToList();

        var bookGenres = genreEntities
            .Select(g => new BookGenre { Genre = g })
            .ToList();

        var book = new Book
        {
            Name = request.Name,
            ReleaseDate = request.ReleaseDate,
            PublishingHouse = publishingHouse,
        
            Authors = bookAuthors,
            Genres = bookGenres
        };

        _db.Books.Add(book);

        await _db.SaveChangesAsync();

        return book.ToBookDto();
    }
}