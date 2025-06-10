namespace FinalTest.Models;

public class BookGenre
{
    public int IdBook { get; set; }
    public Book Book { get; set; } = null!;
    
    public int IdGenre { get; set; }
    public Genre Genre { get; set; } = null!;
}