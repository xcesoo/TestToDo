using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public readonly record struct ChangeDescriptionToDoItemCommand(Guid ToDoItemId, string NewDescription) : IRequest;