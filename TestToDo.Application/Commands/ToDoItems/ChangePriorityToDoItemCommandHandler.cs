using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangePriorityToDoItemCommandHandler: IRequestHandler<ChangePriorityToDoItemCommand>
{
    public async Task Handle(ChangePriorityToDoItemCommand request, CancellationToken cancellationToken)
    {
        
    }
}