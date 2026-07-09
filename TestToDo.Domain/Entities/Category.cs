namespace TestToDo.Entities;

public partial class Category
{
    public Guid Id { get; init; }
    public string Name { get; private set; }

    private Category() { } // for ef core

}