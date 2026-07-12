using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class CompleteToDoItemCommandHandler(IToDoItemRepository itemRepository, ICurrentUserProvider currentUser): IRequestHandler<CompleteToDoItemCommand>
{
    public async Task Handle(CompleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemByIdAsync(request.ToDoItemId, currentUser.GetUserId(), cancellationToken)
                ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        i.Complete();
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}