using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangeDescriptionToDoItemCommandHandler: IRequestHandler<ChangeDescriptionToDoItemCommand>
{
    public async Task Handle(ChangeDescriptionToDoItemCommand request, CancellationToken cancellationToken)
    {
        
    }
}