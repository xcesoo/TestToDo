using TestToDo.Entities;
using TestToDo.Enums;

namespace TestToDo.Interfaces;

public interface IToDoItemRepository
{
    Task<IReadOnlyCollection<ToDoItem>> GetToDoItemsAsync(Guid userId, int page, int pageSize, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<ToDoItem>> SearchToDoItemsAsync(
        Guid userId,
        string? searchTerm, 
        Guid? categoryId,
        EPriority[]? priority,
        DateTime? startDateCreated, DateTime? endDateCreated,
        DateTime? startDateDeadline, DateTime? endDateDeadline,
        DateTime? startDateCompleted, DateTime? endDateCompleted,
        bool? completed,
        int page, int pageSize, CancellationToken cancellationToken);
    Task<ToDoItem?> GetToDoItemByIdAsync(Guid id, Guid userId, CancellationToken cancellationToken);
    Task AddToDoItemAsync(ToDoItem toDoItem, CancellationToken cancellationToken);
    Task DeleteToDoItemAsync(Guid id, Guid userId,  CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}