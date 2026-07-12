using TestToDo.Entities;

namespace TestToDo.Interfaces;

public interface IToDoItemRepository
{
    Task<IReadOnlyCollection<ToDoItem>> GetToDoItemsAsync(Guid userId, int page, int pageSize, CancellationToken cancellationToken);
    Task<ToDoItem?> GetToDoItemByIdAsync(Guid id, Guid userId, CancellationToken cancellationToken);
    Task AddToDoItemAsync(ToDoItem toDoItem, CancellationToken cancellationToken);
    Task DeleteToDoItemAsync(Guid id, Guid userId,  CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}