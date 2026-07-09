using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public readonly record struct ChangeCategoryToDoItemCommand(Guid ToDoItemId, Guid NewCategory) : IRequest;