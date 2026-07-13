using MediatR;
using TestToDo.Contracts.DTOs;
using TestToDo.ValueObjects;

namespace TestToDo.Application.Commands.Users;

public readonly record struct RegisterUserCommand(Email Email, string Password, string Name): IRequest<TokenResponseDto>;