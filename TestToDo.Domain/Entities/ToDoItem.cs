using TestToDo.Enums;

namespace TestToDo.Entities;

public partial class ToDoItem
{
    public Guid Id { get; init; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? Deadline { get; private set; }
    public EPriority Priority { get; private set; }
    
    public bool IsCompleted { get; private set; }
    public DateTime? CompletedAt { get; private set; } 
    private ToDoItem(){} // for ef core
}