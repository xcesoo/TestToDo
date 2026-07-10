using MediatR;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class ChangeCategoryToDoItemCommandHandler(
    IToDoItemRepository itemRepository,
    ICategoryRepository categoryRepository) : IRequestHandler<ChangeCategoryToDoItemCommand>
{
    public async Task Handle(ChangeCategoryToDoItemCommand request, CancellationToken cancellationToken)
    {
        var i = await itemRepository.GetToDoItemByIdAsync(request.ToDoItemId, cancellationToken)
            ?? throw new KeyNotFoundException($"ToDoItem with id {request.ToDoItemId} not found");
        
        var ct = await categoryRepository.GetCategoryByIdAsync(request.NewCategory, cancellationToken)
                ?? throw new KeyNotFoundException($"Category with id {request.NewCategory} not found");
        i.ChangeCategory(ct);
        await itemRepository.SaveChangesAsync(cancellationToken);
    }
}