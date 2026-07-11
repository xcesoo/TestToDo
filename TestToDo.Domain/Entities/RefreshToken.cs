namespace TestToDo.Entities;

public partial class RefreshToken
{
    public Guid Id { get ; init; }
    public string Token { get; init; }
    public DateTime ExpiryDate { get; init; }
    public bool IsRevoked { get; private set; }
    public DateTime CreatedDate { get; init; }
    
    public Guid UserId { get; init; }
    public User User { get; init; } = null!;
    
    private RefreshToken(){} //for ef core
}