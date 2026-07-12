using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Interfaces;
using TestToDo.Application.Extensions;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.ToDoItems;

public class GetToDoItemByIdQueryHandler(IToDoItemRepository itemRepository, ICurrentUserProvider currentUser) : IRequestHandler<GetToDoItemByIdQuery, ToDoItemDto?>
{
    public async Task<ToDoItemDto?> Handle(GetToDoItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await itemRepository.GetToDoItemByIdAsync(request.Id, currentUser.GetUserId(), cancellationToken);
        return item?.ToDto();
    }
}