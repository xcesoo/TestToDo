using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Commands.Users;

public readonly record struct RegisterUserCommand(): IRequest<UserDto>;