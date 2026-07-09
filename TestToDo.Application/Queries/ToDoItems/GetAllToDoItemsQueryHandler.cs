using MediatR;

namespace TestToDo.Application.Queries.ToDoItems;

public class GetAllToDoItemsQueryHandler() : IRequestHandler<GetAllToDoItemsQuery>
{
    public async Task Handle(GetAllToDoItemsQuery request, CancellationToken cancellationToken)
    {
        
    }
};