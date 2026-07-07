namespace TestToDo.Entities;

public class Category
{
    public Guid Id { get; init; }
    public string Name { get; private set; }

    private Category() { } // for ef core

    public static Category Create(string name)
    {
        return new Category
        {
            Id = Guid.CreateVersion7(),
            Name = name
        };
    }

    public static Category Default()
    {
        return new Category
        {
            Id = Guid.Empty,
            Name = "Default"
        };
    }
}