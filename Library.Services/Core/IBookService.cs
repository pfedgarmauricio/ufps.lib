using Library.Services.DTO;

namespace Library.Services.Core;

public interface IBookService
{
    public Task<BookDto?> FetchBookById(Guid id);
    public Task<IEnumerable<BookDto>> FetchBooksByFilter(string? name, string? summary, DateTime? publishingDate, string? genre);
    public Task<IEnumerable<BookDto>> FetchBooksByDateRange(DateTime from, DateTime to);
    public Task<IEnumerable<BookDto>> FetchBooksByAuthor(Guid authorId);
    public Task<BookDto> AddBook(BookDto dto);
}