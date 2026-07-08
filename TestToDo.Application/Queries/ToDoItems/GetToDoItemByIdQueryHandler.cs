using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Mappings;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.ToDoItems;

public class GetToDoItemByIdQueryHandler(IToDoItemRepository itemRepository) : IRequestHandler<GetToDoItemByIdQuery, ToDoItemDto>
{
    public async Task<ToDoItemDto> Handle(GetToDoItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await itemRepository.GetToDoItemById(request.Id, cancellationToken);
        return item == null ? throw new NullReferenceException() : item.ToDto();
    }
}