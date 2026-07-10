namespace TestToDo.Entities;

public partial class Category
{
    //static factory
    public static Category Create(string name, Guid userId)
    {
        return new Category
        {
            Id = Guid.CreateVersion7(),
            UserId = userId,
            Name = name
        };
    }

    public void ChangeName(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        Name = name;
    }
}