using TestToDo.ValueObjects;

namespace TestToDo.Entities;

public partial class User
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public string Name { get; private set; }
    public Email Email { get; private set; } 
    public string PasswordHash { get; private set; }
    private readonly List<RefreshToken> _refreshTokens = new();
    public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens;
    
    private User() { } // for ef core
}