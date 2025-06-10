namespace FinalTest.Models;

public class BookAuthor
{
    public int IdBook { get; set; }
    public Book Book { get; set; } = null!;
    
    public int IdAuthor { get; set; }
    public Author Author { get; set; } = null!;
}