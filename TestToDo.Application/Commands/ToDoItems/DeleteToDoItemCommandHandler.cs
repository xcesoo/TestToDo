using MediatR;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class DeleteToDoItemCommandHandler(IToDoItemRepository itemRepository) : IRequestHandler<DeleteToDoItemCommand>
{
    public async Task Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        await itemRepository.DeleteToDoItem(request.ToDoItemId, cancellationToken);
    }
}