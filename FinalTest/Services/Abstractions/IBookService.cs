using FinalTest.Contracts;
using FinalTest.Contracts.Requests;

namespace FinalTest.Services.Abstractions;

public interface IBookService
{
    Task<BookDto> CreateBookAsync(CreateBookRequest request);
}