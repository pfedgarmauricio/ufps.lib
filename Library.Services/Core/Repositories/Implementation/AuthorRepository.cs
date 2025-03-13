using Library.Services.Entities;
using Library.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Core.Repositories.Implementation;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDbContext _dbContext;

    public AuthorRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Author> AddAuthorAsync(Author author)
    {
        _dbContext.Authors.Add(author);
        await _dbContext.SaveChangesAsync();
        return author;
    }

    public async Task DeleteAuthorAsync(Guid id)
    {
        var existingAuthor = await GetAuthorByIdAsync(id);
        if (existingAuthor == null)
            throw new KeyNotFoundException("Not found.");

        _dbContext.Authors.Remove(existingAuthor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
    {
        return await _dbContext.Authors
            .Include(a => a.Books)
            .ToListAsync();
    }

    public async Task<Author?> GetAuthorByIdAsync(Guid id)
    {
        return await _dbContext.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.ID == id);
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        var existingAuthor = await GetAuthorByIdAsync(author.ID);
        if (existingAuthor == null)
            throw new KeyNotFoundException("Not found.");

        _dbContext.Entry(existingAuthor)
            .CurrentValues
            .SetValues(author);

        existingAuthor.MarkAsUpdated();
        await _dbContext.SaveChangesAsync();
    }
}