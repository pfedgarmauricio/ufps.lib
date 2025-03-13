using Library.Services.Entities;
using Library.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Core.Repositories.Implementation;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _dbContext;

    public BookRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddBookAsync(Book book)
    {
        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();
    }

    public Task DeleteBookAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _dbContext.Books
            .ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(Guid id)
    {
        return await _dbContext.Books
            .FirstOrDefaultAsync(b => b.ID == id);
    }

    public Task UpdateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }
}
