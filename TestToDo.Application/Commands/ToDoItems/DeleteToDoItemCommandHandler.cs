using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand>
{
    public async Task Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        
    }
}