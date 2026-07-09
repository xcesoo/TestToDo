using MediatR;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Categories;

public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand>
{
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await categoryRepository.DeleteCategory(request.CategoryId, cancellationToken);
    }
}