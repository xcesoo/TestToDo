using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class DeleteToDoItemCommandHandler(IToDoItemRepository itemRepository, ICurrentUserProvider currentUser) : IRequestHandler<DeleteToDoItemCommand>
{
    public async Task Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        await itemRepository.DeleteToDoItemAsync(request.ToDoItemId, currentUser.GetUserId(), cancellationToken);
    }
}