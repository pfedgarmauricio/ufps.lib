using Library.Services.Core.Mapping;
using Library.Services.Core.Repositories;
using Library.Services.DTO;
using System.Threading.Tasks;

namespace Library.Services.Core.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookDto> AddBook(BookDto dto)
    {
        try
        {
            var newBook = await _bookRepository.AddBookAsync(dto.FromDto());
            return new BookDto(
                newBook.ID,
                newBook.Title,
                newBook.Summary,
                newBook.PublishingDate,
                newBook.Genre.ToString(),
                newBook.AuthorId
                );
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<BookDto?> FetchBookById(Guid id)
    {
        try
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
                return null;

            return new BookDto(
                book.ID,
                book.Title,
                book.Summary,
                book.PublishingDate,
                book.Genre.ToString(),
                book.AuthorId);

        } catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<BookDto>> FetchBooksByAuthor(Guid authorId)
    {
        try
        {
            var books = await _bookRepository.GetAllBooksAsync();

            if (!books.Any())
                return new List<BookDto>();

            return books
                .Where(b => b.AuthorId == authorId)
                .Select(b => new BookDto(
                    b.ID, b.Title, b.Summary, b.PublishingDate, b.Genre.ToString(), b.AuthorId))
                .ToList();

        } catch (Exception)
        {
            throw;
        }
    }

    public Task<IEnumerable<BookDto>> FetchBooksByDateRange(DateTime from, DateTime to)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookDto>> FetchBooksByFilter(string? name, string? summary, DateTime? publishingDate, string? genre)
    {
        throw new NotImplementedException();
    }
}