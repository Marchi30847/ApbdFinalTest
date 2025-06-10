namespace FinalTest.Contracts;

public class BookDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    
    public ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();
    public ICollection<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
}