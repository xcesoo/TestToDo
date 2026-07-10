using TestToDo.Entities;

namespace TestToDo.Interfaces;

public interface IToDoItemRepository
{
    Task<IReadOnlyCollection<ToDoItem>> GetToDoItemsAsync(CancellationToken cancellationToken);
    Task<ToDoItem?> GetToDoItemByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddToDoItemAsync(ToDoItem toDoItem, CancellationToken cancellationToken);
    Task DeleteToDoItemAsync(Guid id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}