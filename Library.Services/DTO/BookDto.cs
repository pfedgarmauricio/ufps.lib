namespace Library.Services.DTO;

public sealed record BookDto(
    Guid ID,
    string Title,
    string Summary,
    DateTime PublishingDate,
    string Genre,
    Guid AuthorId);