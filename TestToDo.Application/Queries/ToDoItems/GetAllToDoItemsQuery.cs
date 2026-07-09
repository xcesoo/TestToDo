using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Queries.ToDoItems;

public readonly record struct GetAllToDoItemsQuery() : IRequest<IReadOnlyCollection<ToDoItemDto>>; //todo pagination