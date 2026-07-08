using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Queries.ToDoItems;

public record GetToDoItemByIdQuery (Guid Id) : IRequest<ToDoItemDto>;