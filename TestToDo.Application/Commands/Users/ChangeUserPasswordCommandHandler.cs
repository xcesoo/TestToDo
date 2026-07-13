using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Contracts.DTOs;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Users;

public class ChangeUserPasswordCommandHandler(
    ICurrentUserProvider currentUser,
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider) : IRequestHandler<ChangeUserPasswordCommand, TokenResponseDto>
{
    public async Task<TokenResponseDto> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByIdAsync(currentUser.GetUserId(), cancellationToken)
                   ?? throw new KeyNotFoundException("User not found");
        if (!passwordHasher.Verify(request.CurrentPassword, user.PasswordHash)) throw new ArgumentException("Current password does not match");
        user.ChangePasswordHash(passwordHasher.Hash(request.NewPassword));
        var token = new TokenResponseDto(jwtProvider.GenerateAccessJwtToken(user), jwtProvider.GenerateRefreshJwtToken(user));
        user.RevokeAllRefreshTokens();
        user.AddRefreshToken(token.RefreshToken, jwtProvider.GetExpiryRefreshTokenDate());
        await userRepository.SaveChangesAsync(cancellationToken);
        return token;
    }
}