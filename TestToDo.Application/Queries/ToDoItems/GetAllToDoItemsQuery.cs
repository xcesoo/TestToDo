using MediatR;

namespace TestToDo.Application.Queries.ToDoItems;

public readonly record struct GetAllToDoItemsQuery() : IRequest; //todo pagination