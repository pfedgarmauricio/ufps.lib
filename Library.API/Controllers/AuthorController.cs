using Library.API.Requests;
using Library.Services.Core;
using Library.Services.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
    {
        var result = await _authorService.FetchAllAuthors();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AuthorDto?>> GetAuthorById(Guid id)
    {
        var result = await _authorService.FetchAuthorById(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDto>> CreateAuthor(
        [FromBody] CreateAuthorRequest request)
    {
        var result = await _authorService.CreateAuthor(new AuthorDto(
            Guid.Empty, request.Name, request.Nationality, request.DateOfBirth, new List<BookDto>()));

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAuthor(Guid id)
    {
        await _authorService.DeleteAuthorById(id);
        return NoContent();
    }
}
