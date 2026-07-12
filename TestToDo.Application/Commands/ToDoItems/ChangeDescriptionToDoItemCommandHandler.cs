using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangeDescriptionToDoItemCommandHandler(IToDoItemRepository itemRepository, ICurrentUserProvider currentUser): IRequestHandler<ChangeDescriptionToDoItemCommand>
{
    public async Task Handle(ChangeDescriptionToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemByIdAsync(request.ToDoItemId, currentUser.GetUserId(), cancellationToken)
                ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        i.ChangeDescription(request.NewDescription);
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}