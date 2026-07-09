using MediatR;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Categories;

public class ChangeCategoryNameCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<ChangeCategoryNameCommand>
{
    public async Task Handle(ChangeCategoryNameCommand request, CancellationToken cancellationToken)
    {
        var ct = await categoryRepository.GetCategoryById(request.CategoryId, cancellationToken)
            ?? throw new KeyNotFoundException($"Category with id {request.CategoryId} not found");
        ct.ChangeName(request.NewName);
        await categoryRepository.SaveChangesAsync(cancellationToken);
    }
}