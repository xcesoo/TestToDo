using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangeTitleToDoItemCommandHandler(IToDoItemRepository itemRepository, ICurrentUserProvider currentUser): IRequestHandler<ChangeTitleToDoItemCommand>
{
    public async Task Handle(ChangeTitleToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemByIdAsync(request.ToDoItemId, currentUser.GetUserId(), cancellationToken)
                ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        i.ChangeTitle(request.NewTitle);
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}