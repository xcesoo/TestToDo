namespace TestToDo.Application.DTOs;

public record TokenResponseDto
    (
    string AccessToken,
    string RefreshToken
    );