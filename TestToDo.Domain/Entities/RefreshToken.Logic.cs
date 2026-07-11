namespace TestToDo.Entities;

public partial class RefreshToken
{
    public static RefreshToken Create(string token, Guid userId)
    {
        return new RefreshToken
        {
            Id = Guid.CreateVersion7(),
            Token = token,
            CreatedDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddDays(7),
            UserId = userId
        };
    }
    public bool IsExpired => DateTime.UtcNow > ExpiryDate;
    public bool IsActive => !IsRevoked && !IsExpired;
    public void Revoke() => IsRevoked = true;
}