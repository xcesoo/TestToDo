namespace TestToDo.Entities;

public partial class Category
{
    //static factory
    public static Category Create(string name)
    {
        return new Category
        {
            Id = Guid.CreateVersion7(),
            Name = name
        };
    }
    
    //default instance factory
    public static Category Default()
    {
        return new Category
        {
            Id = Guid.Empty,
            Name = "Default"
        };
    }
    
    private void CheckDefault()
    {
        if (Id == Guid.Empty) throw new InvalidOperationException("Default category cannot be changed");
    }

    public void ChangeName(string name)
    {
        CheckDefault();
        Name = name;
    }
}