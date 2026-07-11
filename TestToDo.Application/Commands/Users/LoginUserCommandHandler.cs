using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Users;

public class LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider) : IRequestHandler<LoginUserCommand, TokenResponseDto>
{
    public async Task<TokenResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByEmailAsync(request.Email, cancellationToken)
                   ?? throw new UnauthorizedAccessException("Invalid email or password");
        if (!passwordHasher.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid email or password");
        var token = new TokenResponseDto(
            jwtProvider.GenerateAccessJwtToken(user),
            jwtProvider.GenerateRefreshJwtToken(user));
        user.AddRefreshToken(token.RefreshToken);
        await userRepository.SaveChangesAsync(cancellationToken);
        return token;
    }
}