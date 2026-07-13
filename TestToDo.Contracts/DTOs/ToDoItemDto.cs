using TestToDo.Enums;

namespace TestToDo.Contracts.DTOs;

public record ToDoItemDto(
    Guid Id,
    string Title,
    string? Description,
    string? Category,
    DateTime CreatedAt,
    DateTime? Deadline,
    EPriority Priority,
    bool IsCompleted);