using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Application.Extensions;
using TestToDo.Contracts.DTOs;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.ToDoItems;

public class SearchToDoItemsQueryHandler(IToDoItemRepository itemRepository, ICurrentUserProvider currentUser) : IRequestHandler<SearchToDoItemsQuery, IReadOnlyCollection<ToDoItemDto>>
{
    public async Task<IReadOnlyCollection<ToDoItemDto>> Handle(SearchToDoItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await itemRepository.SearchToDoItemsAsync(
            currentUser.GetUserId(),
            request.Filter,
            request.Pagination.Page, request.Pagination.PageSize, 
            cancellationToken);
        return items.ToDtoCollection();
    }
}