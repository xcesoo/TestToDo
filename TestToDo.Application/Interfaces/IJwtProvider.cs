using TestToDo.Entities;

namespace TestToDo.Application.Interfaces;

public interface IJwtProvider
{
    string GenerateAccessJwtToken(User user);
    string GenerateRefreshJwtToken(User user);
}