using MediatR;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangePriorityToDoItemCommandHandler(IToDoItemRepository itemRepository): IRequestHandler<ChangePriorityToDoItemCommand>
{
    public async Task Handle(ChangePriorityToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemById(request.ToDoItemId, cancellationToken)
                ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        i.ChangePriority(request.NewPriority);
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}