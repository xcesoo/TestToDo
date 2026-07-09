using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangeTitleToDoItemCommandHandler: IRequestHandler<ChangeTitleToDoItemCommand>
{
    public async Task Handle(ChangeTitleToDoItemCommand request, CancellationToken cancellationToken)
    {
        
    }
}