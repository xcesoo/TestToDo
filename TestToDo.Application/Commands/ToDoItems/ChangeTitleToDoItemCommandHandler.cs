using MediatR;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangeTitleToDoItemCommandHandler(IToDoItemRepository itemRepository): IRequestHandler<ChangeTitleToDoItemCommand>
{
    public async Task Handle(ChangeTitleToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemByIdAsync(request.ToDoItemId, cancellationToken)
                ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        i.ChangeTitle(request.NewTitle);
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}