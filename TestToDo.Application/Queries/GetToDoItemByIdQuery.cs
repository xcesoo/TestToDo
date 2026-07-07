using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Queries;

public record GetToDoItemByIdQuery (Guid Id) : IRequest<ToDoItemDto>;