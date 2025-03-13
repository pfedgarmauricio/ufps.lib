using Library.Services.Entities.Base;
using Library.Services.Entities.Enum;

namespace Library.Services.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public DateTime PublishingDate { get; set; }
    public Genre Genre { get; set; }
    public Guid AuthorId { get; set; }
    public virtual Author Author { get; set; }

    public Book() { }

    public Book(Guid id, string title, string summary, 
        DateTime publishingDate, Genre genre, Author author) : base(id)
    {
        Title = title;
        Summary = summary;
        PublishingDate = publishingDate;
        Genre = genre;
        AuthorId = author.ID;
        Author = author;
    }
}