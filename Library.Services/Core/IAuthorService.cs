using Library.Services.DTO;

namespace Library.Services.Core;

public interface IAuthorService
{
    public Task<AuthorDto> CreateAuthor(AuthorDto dto);
    public Task<IEnumerable<AuthorDto>> FetchAllAuthors();
    public Task<AuthorDto?> FetchAuthorById(Guid id);
    public Task DeleteAuthorById(Guid id);
}
