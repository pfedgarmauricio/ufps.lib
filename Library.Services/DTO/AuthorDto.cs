namespace Library.Services.DTO;

public sealed record AuthorDto(
    Guid ID, string Name, string Nationality, DateTime DateOfBirth, IEnumerable<BookDto> Books);