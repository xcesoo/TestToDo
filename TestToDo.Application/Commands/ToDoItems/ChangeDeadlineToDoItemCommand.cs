using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public readonly record struct ChangeDeadlineToDoItemCommand(Guid ToDoItemId, DateTime NewDeadline) : IRequest;