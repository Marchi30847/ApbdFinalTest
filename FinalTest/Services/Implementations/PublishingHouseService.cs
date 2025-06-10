using FinalTest.Contracts.Responses;
using FinalTest.Database;
using FinalTest.Mappers;
using FinalTest.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinalTest.Services.Implementations;

public class PublishingHouseService : IPublishingHouseService
{
    private readonly AppDbContext _db;
    
    public PublishingHouseService(AppDbContext db) => _db = db;
    
    public async Task<List<GetAllPublishingHousesResponse>> GetAllPublishingHousesAsync(string? city, string? country)
    {
        var bookHouses = await _db.PublishingHouses
            .Include(ph => ph.Books)
            .ThenInclude(b => b.Genres)
            .ThenInclude(g => g.IdGenre)
            .Include(ph => ph.Books)
            .ThenInclude(b => b.Authors)
            .ThenInclude(a => a.IdAuthor)
            .OrderBy(ph => ph.Country)
            .ThenBy(ph => ph.Name)
            .AsNoTracking()
            .ToListAsync();
        
        if (city != null) 
            bookHouses = bookHouses.Where(ph => ph.City == city).ToList();
        if (country != null)
            bookHouses = bookHouses.Where(ph => ph.Country == country).ToList();
        
        var mapped = bookHouses
            .Select(bh => bh.ToResponse())
            .ToList();
        return mapped;
    }
}
