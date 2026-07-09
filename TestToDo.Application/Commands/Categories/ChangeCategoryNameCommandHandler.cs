using MediatR;

namespace TestToDo.Application.Commands.Categories;

public class ChangeCategoryNameCommandHandler : IRequestHandler<ChangeCategoryNameCommand>
{
    public async Task Handle(ChangeCategoryNameCommand request, CancellationToken cancellationToken)
    {
        
    }
}