using FinalTest.Contracts.Responses;
using FinalTest.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinalTest.Controllers;

[ApiController]
[Route("api/publishing-houses")]
public class PublishingHouseController : ControllerBase
{
    private readonly IPublishingHouseService _publishingHouseService;
    
    public PublishingHouseController(IPublishingHouseService publishingHouseService)
        => _publishingHouseService = publishingHouseService;

    [HttpGet]
    [ProducesResponseType(typeof(List<GetAllPublishingHousesResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GetAllPublishingHousesResponse>>> GetAllPublishingHouses()
    {
        var result = await _publishingHouseService.GetAllPublishingHousesAsync();
        return Ok(result);
    }
}