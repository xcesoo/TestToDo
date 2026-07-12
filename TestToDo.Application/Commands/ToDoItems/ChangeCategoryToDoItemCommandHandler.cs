using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangeCategoryToDoItemCommandHandler(
    IToDoItemRepository itemRepository,
    ICategoryRepository categoryRepository,
    ICurrentUserProvider currentUser) : IRequestHandler<ChangeCategoryToDoItemCommand>
{
    public async Task Handle(ChangeCategoryToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemByIdAsync(request.ToDoItemId, currentUser.GetUserId(), cancellationToken)
            ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        
        var ct = await categoryRepository.GetCategoryByIdAsync(request.NewCategory, currentUser.GetUserId() ,cancellationToken)
                ?? throw new KeyNotFoundException($"Category with id {request.NewCategory} not found");
        i.ChangeCategory(ct);
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}