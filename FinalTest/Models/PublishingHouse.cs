namespace FinalTest.Models;

public class PublishingHouse
{
    public int IdPublishingHouse { get; set; }
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
    
    public ICollection<Book> Books { get; set; } = new List<Book>();
}