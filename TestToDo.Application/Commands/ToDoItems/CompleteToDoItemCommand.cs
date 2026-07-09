using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public readonly record struct CompleteToDoItemCommand(Guid ToDoItemId) : IRequest;