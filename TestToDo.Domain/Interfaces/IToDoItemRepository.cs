using TestToDo.Entities;

namespace TestToDo.Interfaces;

public interface IToDoItemRepository
{
    Task<IReadOnlyCollection<ToDoItem>> GetToDoItems(CancellationToken cancellationToken);
    Task<ToDoItem?> GetToDoItemById(Guid id, CancellationToken cancellationToken);
    Task AddToDoItem(ToDoItem toDoItem, CancellationToken cancellationToken);
    Task DeleteToDoItem(Guid id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}