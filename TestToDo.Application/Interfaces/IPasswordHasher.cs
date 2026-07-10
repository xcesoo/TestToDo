namespace TestToDo.Application.Interfaces;

public interface IPasswordHasher
{
    Task<string> Hash(string password);
    Task<bool> Verify(string hashedPassword, string password);
}