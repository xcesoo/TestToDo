using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Queries.ToDoItems;

public readonly record struct GetAllToDoItemsQuery(int Page, int PageSize) : IRequest<IReadOnlyCollection<ToDoItemDto>>;