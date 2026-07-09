using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangeDeadlineToDoItemCommandHandler: IRequestHandler<ChangeDeadlineToDoItemCommand>
{
    public async Task Handle(ChangeDeadlineToDoItemCommand request, CancellationToken cancellationToken)
    {
        
    }
}