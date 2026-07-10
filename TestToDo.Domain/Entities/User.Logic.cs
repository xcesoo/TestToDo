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