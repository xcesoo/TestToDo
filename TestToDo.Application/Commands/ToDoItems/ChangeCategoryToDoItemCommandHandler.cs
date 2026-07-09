using MediatR;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangeCategoryToDoItemCommandHandler : IRequestHandler<ChangeCategoryToDoItemCommand>
{
    public async Task Handle(ChangeCategoryToDoItemCommand request, CancellationToken cancellationToken)
    {
        
    }
}