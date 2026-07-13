namespace TestToDo.Entities;

public partial class RefreshToken
{
    public static RefreshToken Create(string token, Guid userId, DateTime expiryDate)
    {
        return new RefreshToken
        {
            Id = Guid.CreateVersion7(),
            Token = token,
            CreatedDate = DateTime.UtcNow,
            ExpiryDate = expiryDate,
            UserId = userId
        };
    }
    public bool IsExpired => DateTime.UtcNow > ExpiryDate;
    public bool IsActive => !IsRevoked && !IsExpired;
    public void Revoke() => IsRevoked = true;
}