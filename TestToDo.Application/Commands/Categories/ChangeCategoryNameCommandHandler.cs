using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Categories;

public class ChangeCategoryNameCommandHandler(ICategoryRepository categoryRepository, ICurrentUserProvider currentUser) : IRequestHandler<ChangeCategoryNameCommand>
{
    public async Task Handle(ChangeCategoryNameCommand request, CancellationToken cancellationToken)
    {
        var ct = await categoryRepository.GetCategoryByIdAsync(request.CategoryId, currentUser.GetUserId(), cancellationToken)
            ?? throw new KeyNotFoundException($"Category with id {request.CategoryId} not found");
        ct.ChangeName(request.NewName);
        await categoryRepository.SaveChangesAsync(cancellationToken);
    }
}