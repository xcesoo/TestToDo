using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Entities;
using TestToDo.Enums;

namespace TestToDo.Application.Queries.ToDoItems;

public readonly record struct SearchToDoItemsQuery(
    string? SearchTerm, 
    Guid? CategoryId,
    EPriority[]? Priority,
    DateTime? startDateCreated, DateTime? endDateCreated,
    DateTime? startDateDeadline, DateTime? endDateDeadline,
    DateTime? startDateCompleted, DateTime? endDateCompleted,
    bool? completed,
    int Page, int PageSize) : IRequest<IReadOnlyCollection<ToDoItemDto>>;