using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public readonly record struct ReopenToDoItemCommand(Guid ToDoItemId) : IRequest;