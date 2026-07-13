using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Filters;


namespace TestToDo.Application.Queries.ToDoItems;

public readonly record struct SearchToDoItemsQuery(
    ToDoItemSearchFilter Filter,
    PaginationFilter Pagination) : IRequest<IReadOnlyCollection<ToDoItemDto>>;