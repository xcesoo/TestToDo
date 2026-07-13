using MediatR;
using TestToDo.Contracts.DTOs;
using TestToDo.ValueObjects;

namespace TestToDo.Application.Commands.Users;

public readonly record struct LoginUserCommand(Email Email, string Password) : IRequest<TokenResponseDto>;