using Library.Services.Entities.Base;

namespace Library.Services.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; }
    public string Nationality { get; set; }
    public DateTime DateOfBirth { get; set; }
    public virtual IEnumerable<Book> Books { get; set; }

    public Author() { }

    public Author(Guid id, string name, string nationality, DateTime birthDate) : base(id)
    {
        Name = name;
        Nationality = nationality;
        DateOfBirth = birthDate;
    }
}
