using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public class CompleteToDoItemCommandHandler: IRequestHandler<CompleteToDoItemCommand>
{
    public async Task Handle(CompleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        
    }
}