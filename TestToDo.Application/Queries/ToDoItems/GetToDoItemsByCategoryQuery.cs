using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Entities;

namespace TestToDo.Application.Queries.ToDoItems;

public readonly record struct GetToDoItemsByCategoryQuery(Guid? CategoryId) : IRequest<IReadOnlyCollection<ToDoItemDto>>;