using MediatR;
using TestToDo.Enums;

namespace TestToDo.Application.Commands.ToDoItems;

public readonly record struct ChangePriorityToDoItemCommand(Guid ToDoItemId, EPriority NewPriority) : IRequest;