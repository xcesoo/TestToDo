using MediatR;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class ReopenToDoItemCommandHandler(IToDoItemRepository itemRepository): IRequestHandler<ReopenToDoItemCommand>
{
    public async Task Handle(ReopenToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemById(request.ToDoItemId, cancellationToken)
                ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        i.Reopen();
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}