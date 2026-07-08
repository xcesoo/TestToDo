using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Enums;

namespace TestToDo.Application.Commands.ToDoItems;

public record CreateToDoItemCommand(
    string Title,
    string? Description,
    DateTime? Deadline,
    EPriority? Priority,
    Guid CategoryId
    ) : IRequest<ToDoItemDto>;