using Library.Services.DTO;
using Library.Services.Entities;

namespace Library.Services.Core.Mapping;

public static class AuthorMapping
{
    public static Author FromDto(this AuthorDto dto)
    {
        return new Author
        {
            Name = dto.Name,
            Nationality = dto.Nationality,
            DateOfBirth = dto.DateOfBirth
        };
    }
}