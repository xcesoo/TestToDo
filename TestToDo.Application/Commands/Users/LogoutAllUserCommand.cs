using MediatR;

namespace TestToDo.Application.Commands.Users;

public readonly record struct LogoutAllUserCommand() :  IRequest;