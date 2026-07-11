using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Interfaces;
using TestToDo.Entities;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Users;

public class RegisterUserCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider) : IRequestHandler<RegisterUserCommand, TokenResponseDto>
{
    public async Task<TokenResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existUser = await userRepository.GetUserByEmailAsync(request.Email, cancellationToken);
        if(existUser != null) throw new ArgumentException("User with email already exist", request.Email);
        var user = User.Create(request.Email, passwordHasher.Hash(request.Password), request.Name);
        var token = new TokenResponseDto(jwtProvider.GenerateAccessJwtToken(user), jwtProvider.GenerateRefreshJwtToken(user));
        //todo save refresh
        await userRepository.AddUserAsync(user, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);
        return token;
    }
}