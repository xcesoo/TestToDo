using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public readonly record struct ChangeTitleToDoItemCommand(Guid ToDoItemId, string NewTitle) : IRequest;