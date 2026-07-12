using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class ReopenToDoItemCommandHandler(IToDoItemRepository itemRepository, ICurrentUserProvider currentUser): IRequestHandler<ReopenToDoItemCommand>
{
    public async Task Handle(ReopenToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemByIdAsync(request.ToDoItemId, currentUser.GetUserId(), cancellationToken)
                ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        i.Reopen();
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}