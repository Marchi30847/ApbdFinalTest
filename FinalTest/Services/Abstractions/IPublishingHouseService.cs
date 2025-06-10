using FinalTest.Contracts.Responses;

namespace FinalTest.Services.Abstractions;

public interface IPublishingHouseService
{
    Task<List<GetAllPublishingHousesResponse>> GetAllPublishingHousesAsync(string? city, string? country);
}