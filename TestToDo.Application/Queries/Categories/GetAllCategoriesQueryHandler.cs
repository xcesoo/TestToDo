using MediatR;

namespace TestToDo.Application.Queries.Categories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery>
{
    public async Task Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        
    }
}