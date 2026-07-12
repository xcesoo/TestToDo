using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Categories;

public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, ICurrentUserProvider currentUser) : IRequestHandler<DeleteCategoryCommand>
{
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await categoryRepository.DeleteCategoryAsync(request.CategoryId,currentUser.GetUserId(), cancellationToken);
    }
}