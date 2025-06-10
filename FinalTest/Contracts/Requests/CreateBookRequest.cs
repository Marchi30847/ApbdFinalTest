namespace FinalTest.Contracts.Requests;

public class CreateBookRequest
{
    public string Name { get; set; } = null!;
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    
    public int PublishingHouseId { get; set; }
    public ICollection<int> AuthorIds { get; set; } = new List<int>();
    public ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();
}