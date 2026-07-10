using MediatR;

namespace TestToDo.Application.Commands.Users;

public readonly record struct ChangeUserNameCommand(string Name) : IRequest;