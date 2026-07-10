using MediatR;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangeDeadlineToDoItemCommandHandler(IToDoItemRepository itemRepository): IRequestHandler<ChangeDeadlineToDoItemCommand>
{
    public async Task Handle(ChangeDeadlineToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemByIdAsync(request.ToDoItemId, cancellationToken)
                ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        i.ChangeDeadline(request.NewDeadline);
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}