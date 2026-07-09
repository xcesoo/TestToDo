using MediatR;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangeDescriptionToDoItemCommandHandler(IToDoItemRepository itemRepository): IRequestHandler<ChangeDescriptionToDoItemCommand>
{
    public async Task Handle(ChangeDescriptionToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemById(request.ToDoItemId, cancellationToken)
                ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        i.ChangeDescription(request.NewDescription);
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}