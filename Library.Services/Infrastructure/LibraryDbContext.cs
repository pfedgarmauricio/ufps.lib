using Library.Services.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Infrastructure;

public class LibraryDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>()
            .HasQueryFilter(b => !b.IsDeleted);

        modelBuilder.Entity<Author>()
            .HasQueryFilter(a => !a.IsDeleted);
    }
}