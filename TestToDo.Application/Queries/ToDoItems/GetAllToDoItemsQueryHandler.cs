using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Interfaces;
using TestToDo.Application.Mappings;
using TestToDo.Entities;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.ToDoItems;

public class GetAllToDoItemsQueryHandler(IToDoItemRepository itemRepository, ICurrentUserProvider currentUser) : IRequestHandler<GetAllToDoItemsQuery,  IReadOnlyCollection<ToDoItemDto>>
{
    public async Task<IReadOnlyCollection<ToDoItemDto>> Handle(GetAllToDoItemsQuery request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemsAsync(currentUser.GetUserId(), cancellationToken);
        return i.ToDtoCollection();
    }
};