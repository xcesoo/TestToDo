using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Interfaces;
using TestToDo.Application.Mappings;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.ToDoItems;

public class GetToDoItemsByCategoryQueryHandler(IToDoItemRepository itemRepository, ICurrentUserProvider currentUser) : IRequestHandler<GetToDoItemsByCategoryQuery, IReadOnlyCollection<ToDoItemDto>>
{
    public async Task<IReadOnlyCollection<ToDoItemDto>> Handle(GetToDoItemsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var items = await itemRepository.GetToDoItemsByCategoryAsync(request.CategoryId, currentUser.GetUserId(),
            cancellationToken);
        return items.ToDtoCollection();
    }
}