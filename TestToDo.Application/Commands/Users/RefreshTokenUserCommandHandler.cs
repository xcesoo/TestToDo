using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Users;

public class RefreshTokenUserCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider) : IRequestHandler<RefreshTokenUserCommand, TokenResponseDto>
{
    public async Task<TokenResponseDto> Handle(RefreshTokenUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByRefreshTokenAsync(request.RefreshToken, cancellationToken)
            ?? throw new KeyNotFoundException("User not found");
        
        var exist = user.RefreshTokens.FirstOrDefault(r => r.Token == request.RefreshToken)
            ?? throw new UnauthorizedAccessException("Invalid token");
        
        if(!exist.IsActive) throw new UnauthorizedAccessException("Invalid token");
        
        var token = new TokenResponseDto(jwtProvider.GenerateAccessJwtToken(user), jwtProvider.GenerateRefreshJwtToken(user));
        user.RevokeRefreshToken(request.RefreshToken);
        user.AddRefreshToken(token.RefreshToken);
        await userRepository.SaveChangesAsync(cancellationToken);
        return token;
    }
}