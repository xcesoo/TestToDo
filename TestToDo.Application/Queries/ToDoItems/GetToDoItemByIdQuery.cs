using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Queries.ToDoItems;

public readonly record struct GetToDoItemByIdQuery (Guid Id) : IRequest<ToDoItemDto?>;