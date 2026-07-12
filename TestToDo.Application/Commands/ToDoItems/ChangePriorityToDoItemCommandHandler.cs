using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangePriorityToDoItemCommandHandler(IToDoItemRepository itemRepository, ICurrentUserProvider currentUser): IRequestHandler<ChangePriorityToDoItemCommand>
{
    public async Task Handle(ChangePriorityToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemByIdAsync(request.ToDoItemId, currentUser.GetUserId(), cancellationToken)
                ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        i.ChangePriority(request.NewPriority);
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}