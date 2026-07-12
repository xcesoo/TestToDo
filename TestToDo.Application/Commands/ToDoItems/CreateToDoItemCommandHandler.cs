using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Interfaces;
using TestToDo.Application.Mappings;
using TestToDo.Entities;
using TestToDo.Enums;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class CreateToDoItemCommandHandler(
    IToDoItemRepository itemRepository, 
    ICategoryRepository categoryRepository,
    ICurrentUserProvider currentUser) : IRequestHandler<CreateToDoItemCommand, ToDoItemDto>
{
    public async Task<ToDoItemDto> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
    {
        Category? ct = null;
        if (request.CategoryId.HasValue)
        {
            ct = await categoryRepository.GetCategoryByIdAsync(request.CategoryId, currentUser.GetUserId(), cancellationToken)
                 ?? throw new KeyNotFoundException($"Category with id {request.CategoryId} not found");
        }
        var item = ToDoItem.Create(
            title: request.Title,
            userId: currentUser.GetUserId(),
            category: ct,
            deadline: request.Deadline,
            description: request.Description ?? null,
            priority: request.Priority ?? EPriority.Medium);
        await itemRepository.AddToDoItemAsync(item, cancellationToken);
        await itemRepository.SaveChangesAsync(cancellationToken);
        return item.ToDto();
    }
}