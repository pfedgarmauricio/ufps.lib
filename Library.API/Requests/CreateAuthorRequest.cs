namespace Library.API.Requests;

public sealed record CreateAuthorRequest(
    string Name, string Nationality, DateTime DateOfBirth);
