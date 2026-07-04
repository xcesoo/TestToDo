using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Enums;

namespace TestToDo.Application.Commands;

public record CreateToDoItemCommand(
    string Title,
    string? Description,
    string? Category,
    DateTime? Deadline,
    EPriority Priority
    ) : IRequest<ToDoItemDto>;