namespace FinalTest.Contracts.Responses;

public class GetAllPublishingHousesResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
    
    public ICollection<BookDto> Books { get; set; } = new List<BookDto>();
}