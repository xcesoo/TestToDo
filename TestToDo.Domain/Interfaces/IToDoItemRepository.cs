using TestToDo.Entities;

namespace TestToDo.Interfaces;

public interface IToDoItemRepository
{
    Task<IEnumerable<ToDoItem>> GetToDoItems();
    Task<ToDoItem> GetToDoItemById(int id);
    Task<ToDoItem> AddToDoItem(ToDoItem toDoItem);
    Task<ToDoItem> UpdateToDoItem(ToDoItem toDoItem);
    Task DeleteToDoItem(ToDoItem toDoItem);
}