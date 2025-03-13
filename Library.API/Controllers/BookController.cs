using Library.API.Requests;
using Library.Services.Core;
using Library.Services.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BookDto?>> GetBookById(Guid id)
    {
        var result = await _bookService.FetchBookById(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> AddBook(
        [FromBody] CreateBookRequest request)
    {
        var result = await _bookService.AddBook(new BookDto(
            Guid.Empty, request.Title, request.Summary, request.PublishingDate, request.Genre, request.AuthorId));
        return Ok(result);
    }
}
