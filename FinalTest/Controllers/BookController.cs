using FinalTest.Contracts;
using FinalTest.Contracts.Requests;
using FinalTest.Exceptions;
using FinalTest.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinalTest.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    
    public BookController(IBookService bookService)
        => _bookService = bookService;

    [HttpPost]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookDto>> AddBook([FromBody] CreateBookRequest request)
    {
        try
        {
            var result = await _bookService.CreateBookAsync(request);

            return Created($"/api/books/{result.Id}", result);
        }
        catch (AuthorNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (PublishingHouseNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
}