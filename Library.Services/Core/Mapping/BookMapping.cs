using Library.Services.DTO;
using Library.Services.Entities;
using Library.Services.Entities.Enum;

namespace Library.Services.Core.Mapping;

public static class BookMapping
{
    public static Book FromDto(this BookDto dto)
    {
        return new Book
        {
            Title = dto.Title,
            Summary = dto.Summary,
            PublishingDate = dto.PublishingDate,
            Genre = (Genre)Enum.Parse(typeof(Genre), dto.Genre),
            AuthorId = dto.AuthorId
        };
    }
}