using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Commands.Users;

public readonly record struct LoginUserCommand() : IRequest; //todo return jwt