using MediatR;
using TestToDo.ValueObjects;

namespace TestToDo.Application.Commands.Users;

public readonly record struct ChangeUserEmailCommand(Email Email) : IRequest;