namespace Library.API.Requests;

public sealed record CreateBookRequest(
    string Title, string Summary, DateTime PublishingDate, string Genre, Guid AuthorId);
