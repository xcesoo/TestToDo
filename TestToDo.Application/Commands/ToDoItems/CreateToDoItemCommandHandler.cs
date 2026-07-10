using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Mappings;
using TestToDo.Entities;
using TestToDo.Enums;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.ToDoItems;

public class CreateToDoItemCommandHandler(IToDoItemRepository itemRepository, ICategoryRepository categoryRepository) : IRequestHandler<CreateToDoItemCommand, ToDoItemDto>
{
    public async Task<ToDoItemDto> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var ct = await categoryRepository.GetCategoryByIdAsync(request.CategoryId,cancellationToken);
        var item = ToDoItem.Create(
            title: request.Title,
            userId: Guid.Empty, //TODO USE IDENTITY
            category: ct,
            deadline: request.Deadline,
            description: request.Description ?? null,
            priority: request.Priority ?? EPriority.Medium);
        await itemRepository.AddToDoItemAsync(item, cancellationToken);
        await itemRepository.SaveChangesAsync(cancellationToken);
        return item.ToDto();
    }
}