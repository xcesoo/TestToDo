using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Interfaces;
using TestToDo.Application.Extensions;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.ToDoItems;

public class SearchToDoItemsQueryHandler(IToDoItemRepository itemRepository, ICurrentUserProvider currentUser) : IRequestHandler<SearchToDoItemsQuery, IReadOnlyCollection<ToDoItemDto>>
{
    public async Task<IReadOnlyCollection<ToDoItemDto>> Handle(SearchToDoItemsQuery request, CancellationToken cancellationToken)
    {
        var safePageSize = request.PageSize > 366 ? 366 : request.PageSize;
        var safePage = request.Page < 1 ? 1 : request.Page;
        var items = await itemRepository.SearchToDoItemsAsync(
            currentUser.GetUserId(),
            request.SearchTerm,
            request.CategoryId,
            request.Priority,
            request.startDateCreated, request.endDateCreated,
            request.startDateDeadline, request.endDateDeadline,
            request.startDateCompleted, request.endDateCompleted,
            request.completed,
            safePage, safePageSize, 
            cancellationToken);
        return items.ToDtoCollection();
    }
}