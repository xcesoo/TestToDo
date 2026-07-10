namespace TestToDo.Entities;

public partial class User
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public string Name { get; private set; }
    public string Email { get; private set; } //todo value object
    public string PasswordHash { get; private set; }
    
    
    private User() { } // for ef core
}