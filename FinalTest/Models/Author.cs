namespace FinalTest.Models;

public class Author
{
    public int IdAuthor { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    
    public ICollection<BookAuthor> Books { get; set; } = new List<BookAuthor>();
}