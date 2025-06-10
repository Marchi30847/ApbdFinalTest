namespace FinalTest.Models;

public class Book
{
    public int IdBook { get; set; }
    public string Name { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    
    public int IdPublishingHouse { get; set; }
    public PublishingHouse PublishingHouse { get; set; } = null!;
    
    public ICollection<BookGenre> Genres { get; set; } = new List<BookGenre>();
    public ICollection<BookAuthor> Authors { get; set; } = new List<BookAuthor>();
}