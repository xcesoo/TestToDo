using MediatR;
using TestToDo.Contracts.DTOs;

namespace TestToDo.Application.Commands.Users;

public readonly record struct LoginUserCommand(string Email, string Password) : IRequest<TokenResponseDto>;