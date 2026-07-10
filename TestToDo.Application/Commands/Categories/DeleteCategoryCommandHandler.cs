using MediatR;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Categories;

public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand>
{
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        if(request.CategoryId == Guid.Empty) throw new InvalidOperationException($"Default category cannot be deleted");
        await categoryRepository.DeleteCategoryAsync(request.CategoryId, cancellationToken);
    }
}