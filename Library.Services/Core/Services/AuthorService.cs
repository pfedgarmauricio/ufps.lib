using Library.Services.Core.Mapping;
using Library.Services.Core.Repositories;
using Library.Services.DTO;
using System.Diagnostics;

namespace Library.Services.Core.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<AuthorDto> CreateAuthor(AuthorDto dto)
    {
        try
        {
            var newAuthor = await _authorRepository.AddAuthorAsync(dto.FromDto());
            return new AuthorDto(
                newAuthor.ID, 
                newAuthor.Name, 
                newAuthor.Nationality, 
                newAuthor.DateOfBirth,
                new List<BookDto>());
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteAuthorById(Guid id)
    {
        try
        {
            await _authorRepository.DeleteAuthorAsync(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<AuthorDto>> FetchAllAuthors()
    {
        try
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();

            if (!authors.Any())
                return new List<AuthorDto>();

            return authors.Select(x => new AuthorDto(
                x.ID,
                x.Name,
                x.Nationality,
                x.DateOfBirth,
                x.Books.Select(x => new BookDto(x.ID, x.Title, x.Summary, x.PublishingDate, x.Genre.ToString(), x.AuthorId))));
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<AuthorDto?> FetchAuthorById(Guid id)
    {
        try
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);

            if (author == null)
                return null;

            return new AuthorDto(
                author.ID,
                author.Name, 
                author.Nationality, 
                author.DateOfBirth, 
                author.Books.Select(x => new BookDto(x.ID, x.Title, x.Summary, x.PublishingDate, x.Genre.ToString(), x.AuthorId)));
        }
        catch (Exception)
        {
            throw;
        }
    }
}