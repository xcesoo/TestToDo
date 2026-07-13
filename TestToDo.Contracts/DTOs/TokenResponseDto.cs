namespace TestToDo.Contracts.DTOs;

public record TokenResponseDto
    (
    string AccessToken,
    string RefreshToken
    );