using MediatR;
using TestToDo.Contracts.DTOs;

namespace TestToDo.Application.Commands.Users;

public readonly record struct RegisterUserCommand(string Email, string Password, string Name): IRequest<TokenResponseDto>;