using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Commands.Users;

public readonly record struct RefreshTokenUserCommand(string RefreshToken) : IRequest<TokenResponseDto>;