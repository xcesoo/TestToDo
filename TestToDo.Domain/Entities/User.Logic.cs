namespace TestToDo.Entities;

public partial class User
{
    public static User Create(string email, string passwordHash, string name = "Unknown")
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);

        return new User
        {
            Id = Guid.CreateVersion7(),
            Name =  name,
            Email =  email,
            PasswordHash = passwordHash,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void AddRefreshToken(string token, DateTime expiryDate)
    {
        _refreshTokens.RemoveAll(t => !t.IsActive);
        if (_refreshTokens.Count >= 5)
        {
            var oldest = _refreshTokens.OrderBy(t => t.CreatedDate).First();
            _refreshTokens.Remove(oldest);
        }

        _refreshTokens.Add(RefreshToken.Create(token, Id, expiryDate));
}

    public void RevokeRefreshToken(string refreshToken)
    {
        _refreshTokens.FirstOrDefault(t=> t.Token == refreshToken)?.Revoke();
    }

    public void RevokeAllRefreshTokens()
    {
        foreach (var token in _refreshTokens) token.Revoke();
    }
    

    public void ChangeName(string newName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(newName);
        Name = newName;
    }

    public void ChangeEmail(string newEmail)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(newEmail);
        Email = newEmail;
    }
    public void ChangePasswordHash(string newPasswordHash)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(newPasswordHash);
        PasswordHash = newPasswordHash;
    }
}