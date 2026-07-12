using MediatR;

namespace TestToDo.Application.Commands.Users;

public readonly record struct LogoutUserCommand(string RefreshToken) :  IRequest;