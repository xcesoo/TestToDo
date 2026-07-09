using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public class ReopenToDoItemCommandHandler: IRequestHandler<ReopenToDoItemCommand>
{
    public async Task Handle(ReopenToDoItemCommand request, CancellationToken cancellationToken)
    {
        
    }
}