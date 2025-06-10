namespace FinalTest.Exceptions;

public class PublishingHouseNotFoundException : KeyNotFoundException
{
    public PublishingHouseNotFoundException(int id)
        : base($"Publishing house with id {id} not found.")
    {
    }
}