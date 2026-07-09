using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public readonly record struct DeleteToDoItemCommand(Guid ToDoItemId) : IRequest;