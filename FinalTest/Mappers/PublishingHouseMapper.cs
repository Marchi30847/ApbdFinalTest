using FinalTest.Contracts.Responses;
using FinalTest.Models;

namespace FinalTest.Mappers;

public static class PublishingHouseMapper
{
    public static GetAllPublishingHousesResponse ToResponse(this PublishingHouse publishingHouse)
    {
        return new GetAllPublishingHousesResponse
        {
            Id = publishingHouse.IdPublishingHouse,
            Name = publishingHouse.Name,
            Country = publishingHouse.Country,
            City = publishingHouse.City,
            Books = publishingHouse.Books
                .Select(b => b.ToBookDto())
                .ToList()
        };
    }
}