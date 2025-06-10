namespace FinalTest.Models;

public class Genre
{
    public int IdGenre { get; set; }
    public string Name { get; set; } = null!;
    
    public ICollection<BookGenre> Books { get; set; } = new List<BookGenre>();
}