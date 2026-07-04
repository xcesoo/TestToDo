using TestToDo.Enums;

namespace TestToDo.Entities;

public partial class ToDoItem
{
    // static factory
    public static ToDoItem Create(
        string title, 
        Category? category =  null, 
        DateTime? deadline = null,
        string description = "",
        EPriority priority = EPriority.Medium)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException($"Title cannot be null or empty", nameof(title));

        category ??= Category.Default();
        
        return new ToDoItem
        {
            Id = Guid.CreateVersion7(),
            Title = title,
            Description = description,
            CategoryId = category.Id,
            Category = category,
            CreatedAt = DateTime.UtcNow,
            Deadline = deadline,
            Priority = priority
        };
    }

    public void ChangeDeadline(DateTime deadline) => Deadline = deadline;
    public void ChangeTitle(string title) => Title =  title;
    public void ChangeDescription (string description)=> Description = description;

    public void ChangeCategory(Category category)
    {
        Category = category;
        CategoryId = category.Id;
    }
    public void ChangePriority(EPriority priority) => Priority =  priority;
}