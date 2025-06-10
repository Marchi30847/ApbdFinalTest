namespace FinalTest.Exceptions;

public class AuthorNotFoundException : KeyNotFoundException
{
    public AuthorNotFoundException()
        : base("Author not found.")
    {
    }
}