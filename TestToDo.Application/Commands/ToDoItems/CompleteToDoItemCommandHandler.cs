using MediatR;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class CompleteToDoItemCommandHandler(IToDoItemRepository itemRepository): IRequestHandler<CompleteToDoItemCommand>
{
    public async Task Handle(CompleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemById(request.ToDoItemId, cancellationToken)
                ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        i.Complete();
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}