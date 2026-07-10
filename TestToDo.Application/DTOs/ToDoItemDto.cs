using TestToDo.Enums;

namespace TestToDo.Application.DTOs;

public record ToDoItemDto(
    Guid Id,
    string Title,
    string? Description,
    string? Category,
    DateTime CreatedAt,
    DateTime? Deadline,
    EPriority Priority,
    bool IsCompleted);